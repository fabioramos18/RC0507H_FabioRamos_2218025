using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RC5RC7.Model;
using Dapper.Contrib.Extensions;

namespace RC5RC7.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CriancasControler : ControllerBase
    {
        private const string ConnectionString = "Server=localhost;Database=santa;Uid=root;Pwd=";

        // GET: api/<PresentsController>
        [HttpGet]
        public IEnumerable<Criancas> Get()
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.GetAll<Criancas>();

            return res;
        }

        // GET api/<PresentsController>
        [HttpGet("{crianca_id}")]
        public Criancas Get(int crianca_id)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.Get<Criancas>(crianca_id);

            return res;
        }

        // POST api/<PresentsController>
        [HttpPost]
        public Criancas Post([FromBody] Criancas cri)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var idNewRec = cn.Insert<Criancas>(cri);

            var res = cn.Get<Criancas>(idNewRec);

            return res;
        }

        // PUT api/<PresentsController>
        [HttpPut("{crianca_id}")]
        public ActionResult<Criancas> Put(int crianca_id, [FromBody] Criancas cri)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var recLido = cn.Get<Criancas>(crianca_id);

            if (recLido != null)
            {
                recLido.nome = cri.nome;
                recLido.idade = cri.idade;
                recLido.presente_id = cri.presente_id;
                recLido.comportamento_id = cri.comportamento_id;

                bool updated = cn.Update<Criancas>(recLido);

                return Ok(recLido);
            }
            else
            {
                return NotFound();

            }
        }

        // DELETE api/<PresentsController>
        [HttpDelete("{crianca_id}")]
        public ActionResult Delete(int crianca_id)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.Get<Criancas>(crianca_id);

            if (res != null)
            {
                bool recsDeleted = cn.Delete<Criancas>(res);
                return Ok();
            }
            else
            {
                return NotFound();

            }


        }
    }
}
