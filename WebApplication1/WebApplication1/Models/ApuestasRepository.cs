﻿using System;
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
 
                float probabilidadOver = 0;
                double cuotaOver = 0;
                probabilidadOver = (float)mercado.Dinero_Over /(float) (mercado.Dinero_Over + mercado.Dinero_Under);
                cuotaOver = (1 / probabilidadOver) * 0.95;
                mercado.Cuota_Over = (float) cuotaOver;

                float probabilidadUnder = 0;
                double cuotaUnder = 0;
                probabilidadUnder = (float)mercado.Dinero_Under / (float)(mercado.Dinero_Under + mercado.Dinero_Over);
                cuotaUnder = (1 / probabilidadUnder) * 0.95;
                mercado.Cuota_Over = (float)cuotaUnder;


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