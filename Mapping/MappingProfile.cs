using AutoMapper;
using System.Linq;
using vega.Controllers.Resources;
using vega.Core.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<PessoaFisica, PessoaFisicaResource>()
            .ForMember(pf => pf.Endereco, opt => opt.MapFrom(v => new EnderecoResource { Estado = v.Estado, Cidade = v.Cidade, Logradouro = v.Logradouro } ));
            CreateMap<PessoaJuridica, PessoaJuridicaResource>()
            .ForMember(pj => pj.Endereco, opt => opt.MapFrom(v => new EnderecoResource { Estado = v.Estado, Cidade = v.Cidade, Logradouro = v.Logradouro } ));
            CreateMap<PessoaFisica, SavePessoaFisicaResource>()            
              .ForMember(pf => pf.Endereco, opt => opt.MapFrom(v => new EnderecoResource { Estado = v.Estado, Cidade = v.Cidade, Logradouro = v.Logradouro } ));
            CreateMap<PessoaJuridica, SavePessoaJuridicaResource>()
            .ForMember(pj => pj.Endereco, opt => opt.MapFrom(v => new EnderecoResource { Estado = v.Estado, Cidade = v.Cidade, Logradouro = v.Logradouro } ));
            CreateMap<PessoaFisicaQuery, PessoaFisicaQueryResource>();
            CreateMap<PessoaJuridicaQuery, PessoaJuridicaQueryResource>();

            // API Resource to Domain

            CreateMap<SavePessoaFisicaResource,PessoaFisica>()
            .ForMember(p => p.Id, opt => opt.Ignore())
            .ForMember(p => p.Estado, opt => opt.MapFrom(pr => pr.Endereco.Estado))
            .ForMember(p => p.Cidade, opt => opt.MapFrom(pr => pr.Endereco.Cidade))
            .ForMember(p => p.Logradouro, opt => opt.MapFrom(pr => pr.Endereco.Logradouro));

            CreateMap<SavePessoaJuridicaResource,PessoaJuridica>()
            .ForMember(p => p.Id, opt => opt.Ignore())
            .ForMember(p => p.Estado, opt => opt.MapFrom(pr => pr.Endereco.Estado))
            .ForMember(p => p.Cidade, opt => opt.MapFrom(pr => pr.Endereco.Cidade))
            .ForMember(p => p.Logradouro, opt => opt.MapFrom(pr => pr.Endereco.Logradouro));

            CreateMap<PessoaFisicaQueryResource,PessoaFisicaQuery>();
            CreateMap<PessoaJuridicaQueryResource,PessoaJuridicaQuery>();            
        }
    }
}