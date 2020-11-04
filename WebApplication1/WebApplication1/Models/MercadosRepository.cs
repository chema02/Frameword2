using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Globalization;


namespace WebApplication1.Models
{
    public class MercadosRepository
    {

        internal List<Mercado> Retrieve()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.ToList();
            }

            return mercados;
        }

        internal Mercado Retrieve(int id)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(s => s.MercadoId == id)
                    .FirstOrDefault();
            }

            return mercado;
        }

        internal void Save(Mercado d)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Mercados.Add(d);
            context.SaveChanges();

        }


        /*internal List<MercadoDTO> RetrieveDTO()
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