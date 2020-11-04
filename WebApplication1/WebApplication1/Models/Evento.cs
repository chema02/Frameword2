using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Equipolocal { get; set; }
        public string Equipovisitante { get; set; }
       // public DateTime Fecha { get; set; }

        public List<Mercado> Mercados{ get; set; }//relación mercado

        public Evento()
        {

        }

        public Evento(int eventoId, string equipolocal, string equipovisitante /*, DateTime fecha*/)
        {
            EventoId = eventoId;
            Equipolocal = equipolocal;
            Equipovisitante = equipovisitante;
            //Fecha = fecha;
        }
    }
    public class EventoDTO
    {
        public string Equipolocal { get; set; }
        public string Equipovisitante { get; set; }
        //public DateTime Fecha { get; }

        public EventoDTO(string equipolocal, string equipovisitante/*, DateTime fecha*/)
        {
            Equipolocal = equipolocal;
            Equipovisitante = equipovisitante;
           // Fecha = fecha;
        }

    }
}