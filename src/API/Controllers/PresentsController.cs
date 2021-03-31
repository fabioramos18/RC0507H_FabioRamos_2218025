using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper.Contrib.Extensions;

using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using RC5RC7.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RC5RC7.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PresentsController : ControllerBase
    {
        private const string ConnectionString = "Server=localhost;Database=santa;Uid=root;Pwd=";
        
        // GET: api/<PresentsController>
        [HttpGet]
        public IEnumerable<presentes> Get()
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.GetAll<presentes>();

            return res;
        }

        // GET api/<PresentsController>/5
        [HttpGet("{presente_id}")]
        public presentes Get(int presente_id)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.Get<presentes>(presente_id);

            return res;
        }

        // POST api/<PresentsController>
        [HttpPost]
        public presentes Post([FromBody] presentes presente)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var idNewRec = cn.Insert<presentes>(presente);

            var res = cn.Get<presentes>(idNewRec);

            return res;
        }

        // PUT api/<PresentsController>
        [HttpPut("{presente_id}")]
        public ActionResult<presentes> Put(int presente_id, [FromBody] presentes presente)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var recLido = cn.Get<presentes>(presente_id);

            if (recLido != null)
            { 
                recLido.nome = presente.nome;
                recLido.quantidade = presente.quantidade;

                bool updated = cn.Update<presentes>(recLido);

                return Ok(recLido);
            }
            else
            {
                return NotFound();

            }
        }

        // DELETE api/<PresentsController>
        [HttpDelete("{presente_id}")]
        public ActionResult Delete(int presente_id)
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);

            var res = cn.Get<presentes>(presente_id);

            if(res != null)
            {
                bool recsDeleted = cn.Delete<presentes>(res);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
