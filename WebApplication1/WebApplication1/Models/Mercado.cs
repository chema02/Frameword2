using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Mercado
    {

        public int MercadoId { get; set; }
        public int EventoId { get; set; }//fk
        public float Over_Under { get; set; }
        public float Cuota_Over { get; set; }
        public float Cuota_Under { get; set; }
        public int Dinero_Over { get; set; }
        public int Dinero_Under { get; set; }

        public Evento Eventos { get; set; }
        public List<Apuesta> Apuestas { get; set; }//relación apuestas
        public Mercado()
        {

        }

        public Mercado(int mercadoId, int eventoId, float over_Under,
                       float cuota_Over, float cuota_Under,
                       int dinero_Over, int dinero_Under)
        {
            MercadoId = mercadoId;
            EventoId = eventoId;
            Over_Under = over_Under;
            Cuota_Over = cuota_Over;
            Cuota_Under = cuota_Under;
            Dinero_Over = dinero_Over;
            Dinero_Under = dinero_Under;
        }

    }
    public class MercadoDTO
    {
        public float Over_Under { get; set; }
        public float Cuota_Over { get; set; }
        public float Cuota_Under { get; set; }

        public MercadoDTO(float over_Under, float cuota_Over, float cuota_Under)
        {
            Over_Under = over_Under;
            Cuota_Over = cuota_Over;
            Cuota_Under = cuota_Under;
        }

    }

}