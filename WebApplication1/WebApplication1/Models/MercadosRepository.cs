using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MercadosRepository
    {

        internal List<Mercado> Retrieve()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Include(p => p.Eventos).ToList();
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
        public MercadoDTO ToDTO(Mercado m)
        {
            return new MercadoDTO(m.Over_Under, m.Cuota_Over, m.Cuota_Under);
        }

        internal List<MercadoDTO> RetrieveDTO()
        {

                List<MercadoDTO> mercados = new List<MercadoDTO>();
                using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados=context.Mercados.Select(p => ToDTO(p)).ToList();
            }
            return mercados;
        }



    }

}