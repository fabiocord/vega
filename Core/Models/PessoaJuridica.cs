using System.ComponentModel.DataAnnotations;

namespace vega.Core.Models
{
    public class PessoaJuridica
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeFantasia { get; set; }
        [Required]
        [StringLength(50)]
        public string RazaoSocial { get; set; }
        [Required]
        public string CNPJ { get; set; }        
        [Required]
        public string Estado { get; set; }
        [Required]        public string Cidade { get; set; }
        
        [StringLength(200)]
        public string Logradouro { get; set; }
    }
}