namespace vega.Controllers.Resources
{
    public class PessoaJuridicaResource
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }        
        public string RazaoSocial { get; set; }        
        public string CNPJ { get; set; }
        public EnderecoResource Endereco { get; set; }    
    }
}