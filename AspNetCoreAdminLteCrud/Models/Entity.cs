﻿using System;

namespace AspNetCoreAdminLteCrud.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
