using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Models
{
    [Table("tbPermissaoTela")]
    public class PermissaoTela
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo obritatorio"), Display(Name ="Formulario")]
        public int FormularioId { get; set; }
        public virtual Formulario Formulario { get; set; }

        [Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [StringLength(20), Required(ErrorMessage = "Campo obritatorio")]
        public string Leitura { get; set; }

        [StringLength(20), Required(ErrorMessage = "Campo obritatorio")]
        public string Incluir { get; set; }

        [StringLength(20), Required(ErrorMessage = "Campo obritatorio")]
        public string Alterar { get; set; }

        [StringLength(20), Required(ErrorMessage = "Campo obritatorio")]
        public string Excluir { get; set; }

    }
}
