using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Citas.Administrador.DAL;
using WebApi.Citas.Administrador.Modelos;

namespace WebApi.Citas.Administrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [AllowAnonymous]
    public class AsesoresController : ControllerBase
    {
        private readonly AsesoresDAL _repository;

        public AsesoresController(AsesoresDAL repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsesoresModel>>> GetAll()
        {
            var asesores = await _repository.GetAllAsync();
            return Ok(asesores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AsesoresModel>> GetById(long id)
        {
            var asesor = await _repository.GetByIdAsync(id);
            if (asesor == null)
            {
                return NotFound();
            }
            return Ok(asesor);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AsesoresModel asesor)
        {
            await _repository.AddAsync(asesor);
            return CreatedAtAction(nameof(GetById), new { id = asesor.Id }, asesor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] AsesoresModel asesor)
        {
            if (id != asesor.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(asesor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
