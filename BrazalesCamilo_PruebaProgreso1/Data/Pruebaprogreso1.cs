using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrazalesCamilo_PruebaProgreso1.Models;

    public class Pruebaprogreso1 : DbContext
    {
        public Pruebaprogreso1 (DbContextOptions<Pruebaprogreso1> options)
            : base(options)
        {
        }

        public DbSet<BrazalesCamilo_PruebaProgreso1.Models.CBrazales> CBrazales { get; set; } = default!;

public DbSet<BrazalesCamilo_PruebaProgreso1.Models.Celular> Celular { get; set; } = default!;
    }
