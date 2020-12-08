using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Models
{
    [Table("tbUsuario")]
    public class Usuario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Grupo Pessoa")]
        public int GrupoPessoaID { get; set; }

        public virtual GrupoPessoa GrupoPessoa { get; set; }

        [StringLength(100), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Login")]
        public string Login { get; set; }

        [StringLength(20), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Password")]
        public string Password { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Maquina")]
        public string Maquina { get; set; }

        public virtual ICollection<PermissaoTela> PermissaoTelas { get; set; }
    }
}
