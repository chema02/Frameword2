using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WebApplication1.Models
{
    public class UsuariosRepository
    {
        internal List<Usuario> Retrieve()
        {
            List<Usuario> usuarios= new List<Usuario>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                usuarios = context.Usuarios.ToList();
            }

            return usuarios;

        }
    }

}