using System;

namespace vega.Controllers.Resources
{
    public class PessoaFisicaResource
    {
        public int Id { get; set; }        
        public string Nome { get; set; }        
        public string SobreNome { get; set; }        
        public DateTime DataNascimento { get; set; }        
        public string CPF { get; set; }
        public EnderecoResource Endereco { get; set; }
    }
}