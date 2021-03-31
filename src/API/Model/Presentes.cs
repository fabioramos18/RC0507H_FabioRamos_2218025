using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace RC5RC7.Model
{
    [Dapper.Contrib.Extensions.Table("Presentes")] 
    public class presentes
    {
        [ExplicitKey]
        public int presente_id { get; set; }
        public int quantidade { get; set; }
        public string nome { get; set; }

    }

}
