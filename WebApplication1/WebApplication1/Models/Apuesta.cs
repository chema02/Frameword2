using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
        public class Apuesta
        {
            public int Id { get; set; }
            public string Email_Usuario { get; set; }
            public int ID_Mercado { get; set; }
            public string Tipo { get; set; }
            public float Cuota { get; set; }
            public int Dinero_Apostado { get; set; }
            public DateTime Fecha { get; }

            public Apuesta(int id, string email_Usuario, int iD_Mercado,
                string tipo, float cuota, int dinero_Apostado, DateTime fecha)
            {
                Id = id;
                Email_Usuario = email_Usuario;
                ID_Mercado = iD_Mercado;
                Tipo = tipo;
                Cuota = cuota;
                Dinero_Apostado = dinero_Apostado;
                Fecha = fecha;
            }
        }
        public class ApuestaDTO
        {
            public string Email_Usuario { get; set; }
            public int ID_Mercado { get; set; }
            public string Tipo { get; set; }
            public float Cuota { get; set; }
            public int Dinero_Apostado { get; set; }
            
            public ApuestaDTO(string email_Usuario, int iD_Mercado,
                string tipo, float cuota, int dinero_Apostado)
            {
                Email_Usuario = email_Usuario;
                ID_Mercado = iD_Mercado;
                Tipo = tipo;
                Cuota = cuota;
                Dinero_Apostado = dinero_Apostado;
                
            }

        }
        public class ApuestaEmailDTO
        {
            
            public string Email_Usuario { get; set; }
            public int ID_Mercado { get; set; }
            public string Tipo { get; set; }
            public float Cuota { get; set; }
            public int Dinero_Apostado { get; set; }
            

        public ApuestaEmailDTO(string email_Usuario, int iD_Mercado,
            string tipo, float cuota, int dinero_Apostado)
            {
            
            Email_Usuario = email_Usuario;
            ID_Mercado = iD_Mercado;
            Tipo = tipo;
            Cuota = cuota;
            Dinero_Apostado = dinero_Apostado;
            
            }
        }

}