namespace vega.Controllers.Resources
{
    public class PessoaJuridicaQueryResource
    {
        public string NomeFantasia { get; set; }        
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}