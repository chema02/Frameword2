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

        }
    }

}