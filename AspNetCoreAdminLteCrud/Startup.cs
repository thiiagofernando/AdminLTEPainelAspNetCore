using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using System.IO;
using AspNetCoreAdminLteCrud.Data;
using AspNetCoreAdminLteCrud.Repository;
using AspNetCoreAdminLteCrud.Interfaces;

namespace AspNetCoreAdminLteCrud
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            

            //Define a pasta App_Data como diretorio de Data Padrão
            string path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");

            //obtem string de conexao com o banco
            services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection").Replace("[DataDirectory]", path)));
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<MeuDbContext>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            //habilita o uso de arquivos estáticos
            app.UseStaticFiles();

            //habilita o roteamento
            app.UseRouting();

            //Define um roteamento padrão
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Paciente}/{action=Index}/{id?}");
            });
        }
    }
}
