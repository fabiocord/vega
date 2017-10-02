using System.ComponentModel.DataAnnotations;

namespace vega.Core.Models
{
    public class Endereco
    {
        public string Estado { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        [StringLength(200)]
        public string Logradouro { get; set; }
    }
}
