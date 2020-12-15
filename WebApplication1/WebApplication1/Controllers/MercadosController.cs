﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<Mercado> Get()
        {
            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.Retrieve();
            //List<MercadoDTO> mercados = repo.RetrieveDTO();
            return mercados;

        }
        /*//GET:api/MercadosDTO
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadosRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();

            return mercados;
        }*/
        // GET: api/Mercados?ID_evento=id & Over_Under=tipo
        public IEnumerable<Mercado> Get(int id, float tipo)
        {
            var repo = new MercadosRepository();
              List<Mercado> mercados= repo.Retrieve();
           // List<Mercado> mercados = repo.RetrieveByTipoandId(id, tipo);
            return mercados;

        }

        // GET: api/Mercados/5
        public Mercado Get(int id)
        {
            var repo = new MercadosRepository();
            Mercado d = repo.Retrieve(id);
            return d;

        }

        // POST: api/Mercados
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadosRepository();
            repo.Save(mercado);

        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }

}
