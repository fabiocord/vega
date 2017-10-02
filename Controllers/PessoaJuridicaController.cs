using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.Core;
using vega.Core.Models;


namespace vega.Controllers
{
    [Route("/api/pessoasJuridicas")]
    public class PessoaJuridicaController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPessoaJuridicaRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PessoaJuridicaController(IMapper mapper, IPessoaJuridicaRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePessoaJuridica([FromBody] SavePessoaJuridicaResource pessoaJuridicaResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pessoaJuridica = mapper.Map<SavePessoaJuridicaResource, PessoaJuridica>(pessoaJuridicaResource);

            repository.Add(pessoaJuridica);
            await unitOfWork.CompleteAsync();

            pessoaJuridica = await repository.GetPessoaJuridica(pessoaJuridica.Id);

            var result = mapper.Map<PessoaJuridica, PessoaJuridicaResource>(pessoaJuridica);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoaJuridica(int id, [FromBody] SavePessoaJuridicaResource pessoaJuridicaResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pessoaJuridica = await repository.GetPessoaJuridica(id);

            if (pessoaJuridica == null)
                return NotFound();

            mapper.Map<SavePessoaJuridicaResource, PessoaJuridica>(pessoaJuridicaResource, pessoaJuridica);

            await unitOfWork.CompleteAsync();

            pessoaJuridica = await repository.GetPessoaJuridica(pessoaJuridica.Id);
            var result = mapper.Map<PessoaJuridica, PessoaJuridicaResource>(pessoaJuridica);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaJuridica(int id)
        {
            var pessoaJuridica = await repository.GetPessoaJuridica(id);

            if (pessoaJuridica == null)
                return NotFound();

            repository.Remove(pessoaJuridica);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaJuridica(int id)
        {
            var pessoaJuridica = await repository.GetPessoaJuridica(id);

            if (pessoaJuridica == null)
                return NotFound();

            var pessoaJuridicaResource = mapper.Map<PessoaJuridica, PessoaJuridicaResource>(pessoaJuridica);

            return Ok(pessoaJuridicaResource);
        }

        [HttpGet]
        public async Task<QueryResultResource<PessoaJuridicaResource>> GetPessoasJuridicas(PessoaJuridicaQueryResource filterResource)
        {
            var filter = mapper.Map<PessoaJuridicaQueryResource, PessoaJuridicaQuery>(filterResource);
            var queryResult = await repository.GetPessoasJuridicas(filter);

            return mapper.Map<QueryResult<PessoaJuridica>, QueryResultResource<PessoaJuridicaResource>>(queryResult);
        }
    }
}