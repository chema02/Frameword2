using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Apuesta> Apuestas { get; set; } //Tabla
        public DbSet<Cuenta> Cuentas { get; set; } //Tabla
        public DbSet<Evento> Eventos { get; set; } //Tabla
        public DbSet<Mercado> Mercados { get; set; } //Tabla
        public DbSet<Usuario> Usuarios { get; set; } //Tabla

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        //Metodo de configuración
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=placemybet2;Uid=root;SslMode=none");//màquina retos

            }
        }

        //Inserción inicial de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario(1, "jose@es", "juan", "sinmiedo", 44));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(2, "juan@melones", "pepico", "algrande", 55));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(1,1,1000,"bancojones",1234567890));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(2,2,5000, "bancodelparke", 554466112));
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "catarrocha", "masanasa"));
            modelBuilder.Entity<Evento>().HasData(new Evento(2, "ceuta", "melilla"));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1,1,(float)1.5,(float)2.5,(float)3.5,1000,2000));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2,2, (float)2.5, (float)1.5, (float)2.5,5000,10000));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1,1,1,"over",(float)1,1000));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(2,2,2,"under",(float)1.5,555));
        }
    }

}