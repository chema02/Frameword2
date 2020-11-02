using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
        public class EventosController : ApiController
        {
            // GET: api/Eventos
            public IEnumerable<Evento> Get()
            {
                var repo = new EventosRepository();
                List<Evento> eventos = repo.Retrieve();
               // List<EventoDTO> eventos = repo.RetrieveDTO();
                return eventos;
            }

            // GET: api/Eventos/5
            public Evento Get(int id)
            {
                // var repo = new EventosRepository();
                // Evento e = repo.Retrieve();
                return null;

            }

            // POST: api/Eventos
            public void Post([FromBody]string value)
            {
            }

            // PUT: api/Eventos/5
            public void Put(int id, [FromBody]string value)
            {
            }

            // DELETE: api/Eventos/5
            public void Delete(int id)
            {
            }
        }

    
}
