using System;
using System.Collections.Generic;
using System.Text;
using JMHDESIGN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JMHDESIGN.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "c", Name = "cliente", NormalizedName = "cliente" }, 
                                                   new IdentityRole { Id = "f", Name = "funcionario", NormalizedName = "funcionario" });
        }

        // adicionar as 'tabelas' à BD
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Projetos> Funcionarios { get; set; }
        public DbSet<Formularios> Formularios { get; set; }
        public DbSet<Funcionarios> Projetos { get; set; }
        public DbSet<ProjetosFuncionarios> ProjetosFuncionarios { get; set; }






    }
}
