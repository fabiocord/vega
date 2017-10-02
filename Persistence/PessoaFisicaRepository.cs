using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core;
using vega.Core.Models;
using vega.Extensions;


namespace vega.Persistence
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly VegaDbContext context;
        public PessoaFisicaRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task<PessoaFisica> GetPessoaFisica(int id)
        {            
            return await context.PessoasFisicas.FindAsync(id);                
        }

        public void Add(PessoaFisica pessoaFisica)
        {
            context.PessoasFisicas.Add(pessoaFisica);
        }

        public void Remove(PessoaFisica pessoaFisica)
        {
            context.Remove(pessoaFisica);
        }

        public async Task<QueryResult<PessoaFisica>> GetPessoasFisicas(PessoaFisicaQuery queryObj)
        {
            var result = new QueryResult<PessoaFisica>();

            var query = context.PessoasFisicas.AsQueryable();
           
            if (!string.IsNullOrWhiteSpace(queryObj.Nome))
                query = query.Where(v => v.Nome == queryObj.Nome);

             if (!string.IsNullOrWhiteSpace(queryObj.SobreNome))
                query = query.Where(v => v.SobreNome == queryObj.SobreNome);
           
            if (!string.IsNullOrWhiteSpace(queryObj.Cpf))   
                query = query.Where(v => v.CPF == queryObj.Cpf);
 
            var columnsMap = new Dictionary<string, Expression<Func<PessoaFisica, object>>>()
            {
                ["nome"] = v => v.Nome,
                ["sobreNome"] = v => v.SobreNome                
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

    }
}