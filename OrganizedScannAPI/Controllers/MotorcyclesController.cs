using Microsoft.AspNetCore.Mvc;
using OrganizedScannApi.Models;
using OrganizedScannApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizedScannApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotorcycleController : ControllerBase
    {
        private readonly MotorcycleService _service;

        public MotorcycleController(MotorcycleService service)
        {
            _service = service;
        }

        // GET api/motorcycle?brand=Honda&year=2022
        [HttpGet]
        public async Task<ActionResult<List<Motorcycle>>> GetAll([FromQuery] string? brand, [FromQuery] int? year)
        {
            var motorcycles = await _service.GetAllAsync(brand, year);
            return Ok(motorcycles);
        }

        // GET api/motorcycle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motorcycle>> GetById(int id)
        {
            var motorcycle = await _service.GetByIdAsync(id);
            if (motorcycle == null)
                return NotFound();

            return Ok(motorcycle);
        }

        // POST api/motorcycle
        [HttpPost]
        public async Task<ActionResult<Motorcycle>> Create(Motorcycle motorcycle)
        {
            var created = await _service.CreateAsync(motorcycle);
            // Retorna 201 Created + local do recurso criado (header Location)
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/motorcycle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Motorcycle motorcycle)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _service.UpdateAsync(id, motorcycle);
            return NoContent(); // 204
        }

        // DELETE api/motorcycle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent(); // 204
        }
    }
}
