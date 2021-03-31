using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using RC5RC7.Model;

namespace RC5RC7.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ComportamentoControler : ControllerBase
    {
        private const string ConnectionString = "Server=localhost;Database=santa;Uid=root;Pwd=YES";

        // GET: api/<PresentsController>
        [HttpGet]
        public IEnumerable<comportamento> Get()
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.GetAll<comportamento>();

            return res;
        }

        // GET api/<PresentsController>
        [HttpGet("{comportamento_id}")]
        public comportamento Get(int comportamento_id)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.Get<comportamento>(comportamento_id);

            return res;
        }

        // POST api/<PresentsController>
        [HttpPost]
        public comportamento Post([FromBody] comportamento comp)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var idNewRec = cn.Insert<comportamento>(comp);

            var res = cn.Get<comportamento>(idNewRec);

            return res;
        }

        // PUT api/<PresentsController>
        [HttpPut("{comportamento_id}")]
        public ActionResult<comportamento> Put(int comportamento_id, [FromBody] comportamento comp)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var recLido = cn.Get<comportamento>(comportamento_id);

            if (recLido != null)
            {
                recLido.condicao = comp.condicao; //se recebe ou nao presente
                recLido.descricao = comp.descricao;

                bool updated = cn.Update<comportamento>(recLido);

                return Ok(recLido);
            }
            else
            {
                return NotFound();

            }
        }

        // DELETE api/<PresentsController>
        [HttpDelete("{comportamento_id}")]
        public ActionResult Delete(int comportamento_id)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.Get<comportamento>(comportamento_id);

            if (res != null)
            {
                bool recsDeleted = cn.Delete<comportamento>(res);
                return Ok();
            }
            else
            {
                return NotFound();

            }


        }
    }
}
