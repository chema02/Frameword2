using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public int UsuarioId { get; set; }//fk//
        public int Saldo { get; set; }
        public string NombreBanco { get; set; }
        public int NumeroCuenta { get; set; }
        public Usuario Usuarios { get; set; }

        public Cuenta(int cuentaId, int usuarioId, int saldo, string nombreBanco, int numeroCuenta)
        {
            CuentaId = cuentaId;
            UsuarioId = usuarioId;
            Saldo = saldo;
            NombreBanco = nombreBanco;
            NumeroCuenta = numeroCuenta;
            
        }
    }
}