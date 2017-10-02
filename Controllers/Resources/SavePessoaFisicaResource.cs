using System;

namespace vega.Controllers.Resources
{
    public class SavePessoaFisicaResource
    {
        public int Id { get; set; }        
        public string Nome { get; set; }        
        public string SobreNome { get; set; }        
        public DateTime DataNascimento { get; set; }        
        public string CPF { get; set; }
        public EnderecoResource Endereco { get; set; }
    }
}