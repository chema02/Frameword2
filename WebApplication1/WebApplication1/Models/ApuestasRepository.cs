using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Globalization;

namespace WebApplication1.Models
{
    public class ApuestasRepository
    {
        /*private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }*/
        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.ToList();
            }

                return apuestas;


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

        /*internal void Save(Apuesta a)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "INSERT INTO Apuestas(Email_Usuario, ID_Mercado, Tipo, Cuota, Dinero_apostado,Fecha) VALUES ('" + a.Email_Usuario + "','" + a.ID_Mercado + "','" + a.Tipo + "','" + a.Cuota + "','" + a.Dinero_Apostado + "','" + a.Fecha + "');";
            Debug.WriteLine("comando" + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                MySqlCommand command1 = con.CreateCommand();
                // command1.CommandText = "Select * from Mercados WHERE ID = " + a.ID_Mercado + "";
                int id = a.ID_Mercado;
                command1.CommandText = "Select * from mercados WHERE ID =@id";
                command1.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command1.ExecuteReader();

                int apuestaOver = 0;
                int apuestaUnder = 0;
                int dineroapostado = a.Dinero_Apostado;

                while (reader.Read())
                {
                    apuestaOver = (int)reader[5];
                    apuestaUnder = (int)reader[6];
                }
                reader.Close();
                MySqlCommand command2 = con.CreateCommand();

                if (a.Tipo == "over")
                {
                    // command2.CommandText = "UPDATE Mercados SET Dinero_Over= " + (apuestaOver + a.Dinero_Apostado) + "WHERE ID = " + a.ID_Mercado+"";
                    command2.CommandText = "UPDATE mercados SET Dinero_Over=(@apuestaOver + @dineroapostado) WHERE ID=@id";
                    command2.Parameters.AddWithValue("@id", id);
                    command2.Parameters.AddWithValue("@dineroapostado", dineroapostado);
                    command2.Parameters.AddWithValue("@apuestaOver", apuestaOver);
                    command2.ExecuteNonQuery();
                }
                else
                {
                    // command2.CommandText = "UPDATE Mercados SET Dinero_Under= " + (apuestaUnder + a.Dinero_Apostado) + "WHERE ID = " + a.ID_Mercado+"";
                    command2.CommandText = "UPDATE mercados SET Dinero_Under=(@apuestaUnder + @dineroapostado) WHERE ID=@id";
                    command2.Parameters.AddWithValue("@id", id);
                    command2.Parameters.AddWithValue("@dineroapostado", dineroapostado);
                    command2.Parameters.AddWithValue("@apuestaUnder", apuestaUnder);
                    command2.ExecuteNonQuery();

                }

                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    apuestaOver = (int)reader1[5];
                    apuestaUnder = (int)reader1[6];
                }
                reader1.Close();

                if (a.Tipo == "over")
                {
                    float probabilidadOver = 0;
                    float cuotaOver = 0;

                    probabilidadOver = apuestaOver / (apuestaOver + apuestaUnder);
                    cuotaOver = (1 / probabilidadOver) * (float)0.95;
                    MySqlCommand command3 = con.CreateCommand();
                    // command2.CommandText = "UPDATE Mercados SET Cuota_Over= " + cuotaOver + "WHERE ID = " + a.ID_Mercado+"";
                    command2.CommandText = "UPDATE mercados SET Cuota_Over = @cuotaOver WHERE ID=@id";
                    command2.Parameters.AddWithValue("@cuotaOver", cuotaOver);
                    command2.Parameters.AddWithValue("@id", id);
                    command2.ExecuteNonQuery();

                }
                else
                {
                    float probabilidadUnder = 0;
                    float cuotaUnder = 0;
                    probabilidadUnder = apuestaUnder / (apuestaOver + apuestaUnder);
                    cuotaUnder = (1 / probabilidadUnder) * (float)0.95;
                    MySqlCommand command3 = con.CreateCommand();
                    // command2.CommandText = "UPDATE Mercados SET Cuota_Under= " + cuotaUnder + "WHERE ID = " + a.ID_Mercado+"";
                    command2.CommandText = "UPDATE mercados SET Cuota_Under = @cuotaUnder WHERE ID=@id";
                    command2.Parameters.AddWithValue("@cuotaUnder", cuotaUnder);
                    command2.Parameters.AddWithValue("@id", id);
                    command2.ExecuteNonQuery();

                }

                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");

            }

        }*/

    }

}