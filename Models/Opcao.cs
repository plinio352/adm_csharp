using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Models
{
    [Table("tbOpcao")]
    public class Opcao
    {
        public int id { get; set; }

        [StringLength(10), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [StringLength(20), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Value")]
        public string Value { get; set; }
    }
}
