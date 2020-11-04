using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
        public class Apuesta
        {
            public int ApuestaId { get; set; }
            public int UsuarioId { get; set; }//fk//
            public int MercadoId { get; set; }//fk
            public string Tipo { get; set; }
            public float Cuota { get; set; }
            public int Dinero_Apostado { get; set; }
           // public DateTime Fecha { get; }

            public Usuario Usuarios { get; set; }
            public Mercado Mercados { get; set; }
            public Apuesta()
            {

            }

            public Apuesta(int apuestaId, int usuarioId, int mercadoId,
                string tipo, float cuota, int dinero_Apostado /*, DateTime fecha*/)//
            {
                ApuestaId = apuestaId;
                UsuarioId = usuarioId;
                MercadoId = mercadoId;
                Tipo = tipo;
                Cuota = cuota;
                Dinero_Apostado = dinero_Apostado;
                //Fecha = fecha;
            }
        }
       /* public class ApuestaDTO
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
        }*/

}