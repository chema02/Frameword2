using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MercadosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }
        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Mercados";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetFloat(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                    m = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetFloat(2), res.GetFloat(3), res.GetFloat(4), res.GetInt32(5), res.GetInt32(6));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }

        }
       /* internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Mercados";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                MercadoDTO m = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetFloat(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                    m = new MercadoDTO(res.GetFloat(2), res.GetFloat(3), res.GetFloat(4));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }
        }*/

        /*internal List<Mercado> RetrieveByTipoandId(int id, float tipo)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            Debug.WriteLine("hola" + id + " " + tipo);
            command.CommandText = "SELECT * FROM mercados WHERE ID_Evento= " + id + " AND Over_Under= '" + tipo + "'";


            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@tipo", tipo);
            Debug.WriteLine("consula:" + command.CommandText);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos2: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetFloat(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                    m = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetFloat(2), res.GetFloat(3), res.GetFloat(4), res.GetInt32(5), res.GetInt32(6));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }
        }*/

    }

}