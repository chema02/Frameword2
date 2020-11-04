using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Usuario
    {
        
        public int UsuarioId { get; set; }//
        public string Email { get; set; }//
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public Cuenta Cuentas { get; set; }//relación cuentas

        public List<Apuesta> Apuestas { get; set; }//relación apuestas

        public Usuario()
        {

        }

        public Usuario(int usuarioId,string email, string nombre, string apellido, int edad)//
        {
            UsuarioId = usuarioId;
            Email = email;//
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }
    }

}