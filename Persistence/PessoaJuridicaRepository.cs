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
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
         private readonly VegaDbContext context;
        public PessoaJuridicaRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task<PessoaJuridica> GetPessoaJuridica(int id)
        {            
            return await context.PessoasJuridicas.FindAsync(id);                
        }

        public void Add(PessoaJuridica pessoaJuridica)
        {
            context.PessoasJuridicas.Add(pessoaJuridica);
        }

        public void Remove(PessoaJuridica pessoaJuridica)
        {
            context.Remove(pessoaJuridica);
        }

        public async Task<QueryResult<PessoaJuridica>> GetPessoasJuridicas(PessoaJuridicaQuery queryObj)
        {
            var result = new QueryResult<PessoaJuridica>();

            var query = context.PessoasJuridicas.AsQueryable();
           
            if (!string.IsNullOrWhiteSpace(queryObj.NomeFantasia))
                query = query.Where(v => v.NomeFantasia == queryObj.NomeFantasia);

             if (!string.IsNullOrWhiteSpace(queryObj.RazaoSocial))
                query = query.Where(v => v.RazaoSocial == queryObj.RazaoSocial);
             
             if (!string.IsNullOrWhiteSpace(queryObj.Cnpj))   
                query = query.Where(v => v.CNPJ == queryObj.Cnpj);
 
            var columnsMap = new Dictionary<string, Expression<Func<PessoaJuridica, object>>>()
            {
                ["nomeFantasia"] = v => v.NomeFantasia,
                ["razaoSocial"] = v => v.RazaoSocial                
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

    }
}