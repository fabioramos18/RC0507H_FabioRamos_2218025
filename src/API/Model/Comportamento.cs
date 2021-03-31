using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace RC5RC7.Model
{
    [Dapper.Contrib.Extensions.Table("comportamento")]
    public class comportamento
    {
        [ExplicitKey]
        public int comportamento_id { get; set; }
        public string descricao { get; set; }
        public bool condicao { get; set; }
    }
    
}
