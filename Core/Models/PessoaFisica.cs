using System;
using System.ComponentModel.DataAnnotations;

namespace vega.Core.Models
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string SobreNome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cidade { get; set; }
         [StringLength(200)]
        public string Logradouro { get; set; }
    }
}