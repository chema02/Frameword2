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

        internal List<Evento> Retrieve()
        {
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }

            return eventos;

        }

        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(e);
            context.SaveChanges();

        }
        internal void Update(int id, Evento d)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            Evento evento;

            evento = context.Eventos
            .Where(e => e.EventoId == id)
            .FirstOrDefault();

            evento.Equipolocal = d.Equipolocal;
            evento.Equipovisitante = d.Equipovisitante;
            context.SaveChanges();

        }
        internal void Delete(int id)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            Evento evento;

            evento = context.Eventos
            .Where(e => e.EventoId == id)
            .FirstOrDefault();

            context.Eventos.Remove(evento);
            context.SaveChanges();

        }

    }

}