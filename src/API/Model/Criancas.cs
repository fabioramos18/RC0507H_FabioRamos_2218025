using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace RC5RC7.Model
{
    [Dapper.Contrib.Extensions.Table("criancas")]
    public class Criancas
    {
        [ExplicitKey]
        public int crianca_id { get; set; }
        public int idade { get; set; }
        public string nome { get; set; }
        public int presente_id { get; set; }
        public int comportamento_id { get; set; }
    }
}
