using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas

        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestasRepository();
              List<Apuesta> apuestas = repo.Retrieve();
            //List<ApuestaDTO> apuestas = repo.RetrieveDTO();

            return apuestas;

        }
        // GET: api/Apuestas?Email_Usuario=usuario &? Id_Mercado=id
       /* public IEnumerable<ApuestaEmailDTO> Get(string usuario, int id)
        {
            var repo = new ApuestasRepository();
            List<ApuestaEmailDTO> apuestas = repo.RetrieveByUsuarioandId_mercado(usuario, id);
            return apuestas;

        }*/
        // GET: api/Apuestas?Id_Mercado=id & Email_Usuario=user
       // [Authorize(Roles = "Admin")]
        /*public IEnumerable<Apuesta> GetEmail(string user, int id)
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestas = repo.RetrieveById_mercadoandEmail_Usuario(user, id);
            return apuestas;

        }*/

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            var repo = new ApuestasRepository();
            Apuesta d = repo.Retrieve(id);
            return d;
        }

        // POST: api/Apuestas
        //[Authorize]
        /*public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);

        }*/

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
