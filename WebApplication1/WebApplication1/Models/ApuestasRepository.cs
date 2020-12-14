using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ApuestasRepository
    {

        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(p => p.Mercados).ToList();
            }

                return apuestas;
        }

        internal Apuesta Retrieve(int id)
        {
            Apuesta apuesta;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas
                    .Where(s => s.ApuestaId == id)
                    .FirstOrDefault();

            }
            return apuesta;
        }
        /*internal List<ApuestaEmailDTO> RetrieveByUsuarioandId_mercado(string usuario, int id)//
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT apuestas.ID, apuestas.Tipo,apuestas.Cuota,apuestas.Dinero_apostado FROM apuestas,eventos WHERE Email_Usuario=@usuario AND ID_Mercado=@id";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@usuario", usuario);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                ApuestaEmailDTO a = null;
                List<ApuestaEmailDTO> apuestas = new List<ApuestaEmailDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos2: " + res.GetInt32(0) + " " + res.GetString(1)
                                    + " " + res.GetInt32(2) + " " + res.GetString(3) + " " +
                                    res.GetFloat(4) + " " + res.GetInt32(5) + " " + res.GetDateTime(6));
                    a = new ApuestaEmailDTO(res.GetString(1), res.GetInt32(2), res.GetString(3), res.GetFloat(4), res.GetInt32(5));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }

        }*/
        /*internal List<Apuesta> RetrieveById_mercadoandEmail_Usuario(string user, int id)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT mercados.Over_Under,apuestas.Tipo,apuestas.Cuota,apuestas.Dinero_apostado FROM apuestas,mercados WHERE Email_Usuario = '@user' AND ID_Mercado = '@id'";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@user", user);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Apuesta a = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos2: " + res.GetInt32(0) + " " + res.GetString(1)
                                    + " " + res.GetInt32(2) + " " + res.GetString(3) + " " +
                                    res.GetFloat(4) + " " + res.GetInt32(5) + " " + res.GetDateTime(6));
                    a = new Apuesta(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetString(3), res.GetFloat(4), res.GetInt32(5), res.GetDateTime(6));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }

        }*/

        /*internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Apuestas";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamosdto: " + res.GetInt32(0) + " " + res.GetString(1)
                                    + " " + res.GetInt32(2) + " " + res.GetString(3) + " " +
                                    res.GetFloat(4) + " " + res.GetInt32(5) + " " + res.GetDateTime(6));
                    a = new ApuestaDTO(res.GetString(1), res.GetInt32(2), res.GetString(3), res.GetFloat(4), res.GetInt32(5));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }

        }*/

        internal void Save(Apuesta a)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            PlaceMyBetContext context = new PlaceMyBetContext();
            Mercado mercado = context.Mercados.First(m => m.MercadoId == a.MercadoId);//recuperamos los mercados que coinciden con el mercadoId de la apuesta
            //sumamos apuestas
            if (a.Tipo == "over")
            {
                mercado.Dinero_Over = mercado.Dinero_Over + a.Dinero_Apostado;
                a.Cuota = mercado.Cuota_Over;
                context.Apuestas.Add(a);

            }
            else
            {
                mercado.Dinero_Under = mercado.Dinero_Under + a.Dinero_Apostado;
                a.Cuota = mercado.Cuota_Under;
                context.Apuestas.Add(a);

            }
            //calculamos probabilidad
            if (a.Tipo == "over")
            {
                float probabilidadOver = 0;
                double cuotaOver = 0;
                probabilidadOver = (float)mercado.Dinero_Over /(float) (mercado.Dinero_Over + mercado.Dinero_Under);
                cuotaOver = (1 / probabilidadOver) * 0.95;
                mercado.Cuota_Over = (float) cuotaOver;
            }
            else
            {
                float probabilidadUnder = 0;
                double cuotaUnder = 0;
                probabilidadUnder = (float)mercado.Dinero_Under / (float)(mercado.Dinero_Under + mercado.Dinero_Over);
                cuotaUnder = (1 / probabilidadUnder) * 0.95;
                mercado.Cuota_Over = (float)cuotaUnder;


            }
            context.Mercados.Update(mercado);
            context.SaveChanges();
        }
        public static ApuestaDTO ToDTO(Apuesta a)
        {
            return new ApuestaDTO(a.UsuarioId,a.MercadoId ,a.Tipo,a.Cuota,a.Dinero_Apostado,a.Mercados);
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {

            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(m => m.Mercados).Select(p => ToDTO(p)).ToList();
            }
            return apuestas;
        }

    }

}