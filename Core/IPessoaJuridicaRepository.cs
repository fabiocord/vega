using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IPessoaJuridicaRepository
    {
        Task<PessoaJuridica> GetPessoaJuridica(int id); 
        void Add(PessoaJuridica pessoaJuridica);
        void Remove(PessoaJuridica pessoaJuridica);
        Task<QueryResult<PessoaJuridica>> GetPessoasJuridicas(PessoaJuridicaQuery filter);
    }
}