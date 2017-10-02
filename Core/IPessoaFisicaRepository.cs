using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IPessoaFisicaRepository
    {
        Task<PessoaFisica> GetPessoaFisica(int id); 
        void Add(PessoaFisica pessoaFisica);
        void Remove(PessoaFisica pessoaFisica);
        Task<QueryResult<PessoaFisica>> GetPessoasFisicas(PessoaFisicaQuery filter);
    }
}