namespace vega.Controllers.Resources
{
    public class SavePessoaJuridicaResource
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }        
        public string RazaoSocial { get; set; }        
        public string CNPJ { get; set; }
        public EnderecoResource Endereco { get; set; }    
    }
}