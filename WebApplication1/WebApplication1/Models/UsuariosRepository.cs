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
       /* private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }*/
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