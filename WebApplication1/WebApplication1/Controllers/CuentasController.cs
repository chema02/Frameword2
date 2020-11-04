using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CuentasController : ApiController
    {
        // GET: api/Cuentas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cuentas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cuentas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cuentas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cuentas/5
        public void Delete(int id)
        {
        }
    }
}
