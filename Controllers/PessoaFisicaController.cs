using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.Core;
using vega.Core.Models;


namespace vega.Controllers
{
    [Route("/api/pessoasFisicas")]
    public class PessoaFisicaController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPessoaFisicaRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PessoaFisicaController(IMapper mapper, IPessoaFisicaRepository repository, IUnitOfWork unitOfWork)
        {
        this.unitOfWork = unitOfWork;
        this.repository = repository;
        this.mapper = mapper;
        }

        [HttpPost]    
        public async Task<IActionResult> CreatePessoaFisica([FromBody] SavePessoaFisicaResource pessoaFisicaResource)
        {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pessoaFisica = mapper.Map<SavePessoaFisicaResource, PessoaFisica>(pessoaFisicaResource);
        
        repository.Add(pessoaFisica);
        await unitOfWork.CompleteAsync();

        pessoaFisica = await repository.GetPessoaFisica(pessoaFisica.Id);

        var result = mapper.Map<PessoaFisica, PessoaFisicaResource>(pessoaFisica);

        return Ok(result);
        }

        [HttpPut("{id}")]    
        public async Task<IActionResult> UpdatePessoaFisica(int id, [FromBody] SavePessoaFisicaResource pessoaFisicaResource)
        {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pessoaFisica = await repository.GetPessoaFisica(id);

        if (pessoaFisica == null)
            return NotFound();

        mapper.Map<SavePessoaFisicaResource, PessoaFisica>(pessoaFisicaResource, pessoaFisica);
        
        await unitOfWork.CompleteAsync();

        pessoaFisica = await repository.GetPessoaFisica(pessoaFisica.Id);
        var result = mapper.Map<PessoaFisica, PessoaFisicaResource>(pessoaFisica);

        return Ok(result);
        }

        [HttpDelete("{id}")]    
        public async Task<IActionResult> DeletePessoaFisica(int id)
        {
        var pessoaFisica = await repository.GetPessoaFisica(id);

        if (pessoaFisica == null)
            return NotFound();

        repository.Remove(pessoaFisica);
        await unitOfWork.CompleteAsync();

        return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaFisica(int id)
        {
        var pessoaFisica = await repository.GetPessoaFisica(id);

        if (pessoaFisica == null)
            return NotFound();

        var pessoaFisicaResource = mapper.Map<PessoaFisica, PessoaFisicaResource>(pessoaFisica);

        return Ok(pessoaFisicaResource);
        }

        [HttpGet]
        public async Task<QueryResultResource<PessoaFisicaResource>> GetPessoasFisicas(PessoaFisicaQueryResource filterResource)
        {
        var filter = mapper.Map<PessoaFisicaQueryResource, PessoaFisicaQuery>(filterResource);
        var queryResult = await repository.GetPessoasFisicas(filter);

        return mapper.Map<QueryResult<PessoaFisica>, QueryResultResource<PessoaFisicaResource>>(queryResult);
        }
    
    } 
}