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
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }
        internal List<Usuario> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Usuarios";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Usuario u = null;
                List<Usuario> usuarios = new List<Usuario>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3));
                    u = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                    usuarios.Add(u);
                }
                con.Close();
                return usuarios;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }

        }
    }

}