using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Mercado
    {

        public int Id { get; set; }
        public int ID_Evento { get; set; }
        public float Over_Under { get; set; }
        public float Cuota_Over { get; set; }
        public float Cuota_Under { get; set; }
        public int Dinero_Over { get; set; }
        public int Dinero_Under { get; set; }

        public Mercado(int id, int iD_Evento, float over_Under,
                       float cuota_Over, float cuota_Under,
                       int dinero_Over, int dinero_Under)
        {
            Id = id;
            ID_Evento = iD_Evento;
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