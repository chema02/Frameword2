using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Usuario
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public Usuario(string email, string nombre, string apellido, int edad)
        {
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }
    }

}