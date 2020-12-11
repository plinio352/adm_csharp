using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Models
{
    [Table("tbConfiguracao")]
    public class Configuracao
    {
        public int Id { get; set; }

        [StringLength(300), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Caminho Base Documento")]
        public string CaminhoBaseDocumento { get; set; }

        [StringLength(300), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Imagem Padrão")]
        public string ImagemPadrao { get; set; }

        [StringLength(2), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Unidade ImgBD")]
        public string UnidadeImgBD { get; set; }

        [StringLength(300), Required(ErrorMessage = "Campo obritatorio"), Display(Name = "Caminho ImgBD")]
        public string CaminhoImgBD { get; set; }

        [StringLength(100), Required(ErrorMessage = "Campo obritatorio")]
        public string Empresa { get; set; }

        [StringLength(15), Required(ErrorMessage = "Campo obritatorio")]
        public string Telefone { get; set; }

        [StringLength(100), Required(ErrorMessage = "Campo obritatorio")]
        public string Rua { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo obritatorio")]
        public string Bairro { get; set; }

        [StringLength(50), Required(ErrorMessage = "Campo obritatorio")]
        public string Cidade { get; set; }

        [StringLength(10), Required(ErrorMessage = "Campo obritatorio"), DisplayFormat(DataFormatString = "{0:##.###-###}", ApplyFormatInEditMode = true)]
        public string Cep { get; set; }
    }
}
