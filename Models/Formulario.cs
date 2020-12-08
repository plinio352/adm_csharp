using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Models
{
    [Table("tbFormulario")]
    public class Formulario
    {
        public int Id { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Formulario")]
        public string Form { get; set; }

        [Required(ErrorMessage = "Campo obritatorio")]
        public int Tag { get; set; }

        public virtual ICollection<PermissaoTela> PermissaoTelas { get; set; }
    }
}
