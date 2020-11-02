using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WebApplication1.Models
{
    public class EventosRepository

    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }
        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Evento e = null;
                List<Evento> eventos = new List<Evento>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }
        }
        /*internal List<EventoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                EventoDTO e = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    e = new EventoDTO(res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }
        }*/
    }

}