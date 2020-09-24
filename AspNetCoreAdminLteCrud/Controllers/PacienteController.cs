using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAdminLteCrud.Interfaces;
using AspNetCoreAdminLteCrud.Models;
using AspNetCoreAdminLteCrud.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAdminLteCrud.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository pacienteRepository
            , IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PacienteViewModel>>(await _pacienteRepository.ObterTodos()));
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(PacienteViewModel pacienteViewModel)
        {
            if (!ModelState.IsValid) return View(pacienteViewModel);

            var fornecedor = _mapper.Map<Paciente>(pacienteViewModel);
            fornecedor.DataCadastro = DateTime.Now;
            await _pacienteRepository.Adicionar(fornecedor);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = await ObterPacientePorId(id);

            if (fornecedorViewModel == null) return NotFound();

            return View(fornecedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PacienteViewModel pacienteViewModel)
        {
            if (id != pacienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(pacienteViewModel);

            var fornecedor = _mapper.Map<Paciente>(pacienteViewModel);
            await _pacienteRepository.Atualizar(fornecedor);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var pacienteViewModel = await ObterPacientePorId(id);
            if (pacienteViewModel == null) return NotFound();

            return View(pacienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pacienteViewModel = await ObterPacientePorId(id);
            if (pacienteViewModel == null) return NotFound();

            await _pacienteRepository.Remover(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var pacienteViewModel = await ObterPacientePorId(id);
            if (pacienteViewModel == null)
            {
                return NotFound();
            }

            return View(pacienteViewModel);
        }

        private async Task<PacienteViewModel> ObterPacientePorId(Guid id)
        {
            return _mapper.Map<PacienteViewModel>(await _pacienteRepository.ObterPorId(id));
        }
    }
}
