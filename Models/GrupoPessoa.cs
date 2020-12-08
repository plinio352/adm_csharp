using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Models
{
    [Table("tbGrupoPessoa")]
    public class GrupoPessoa
    {
        public int ID { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo obritatorio")]
        public string Grupo { get; set; }

        [StringLength(2), Required(ErrorMessage = "Campo obritatorio")]
        public string Sigla { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
