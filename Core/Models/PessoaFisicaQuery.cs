using vega.Extensions;

namespace vega.Core.Models
{
    public class PessoaFisicaQuery  : IQueryObject
    {        
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}