using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CuentasRepository
    {
        internal List<Cuenta> Retrieve()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                cuentas = context.Cuentas.ToList();
            }

            return cuentas;
        }
    }
}