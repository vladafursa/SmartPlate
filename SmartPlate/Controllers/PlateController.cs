using Microsoft.AspNetCore.Mvc;
using SmartPlate.DTOs.Plate;
using SmartPlate.Services.PlateService;

namespace SmartPlate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlateController : ControllerBase
    {
        private readonly IPlateService _plateService;

        public PlateController(IPlateService plateService)
        {
            _plateService = plateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlateResponseDto>>> GetAll()
        {
            var plates = await _plateService.GetAllAsync();
            return Ok(plates);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PlateResponseDto>> GetById(Guid id)
        {
            var plate = await _plateService.GetByIdAsync(id);
            if (plate == null) return NotFound();
            return Ok(plate);
        }
        [HttpPost]
        public async Task<ActionResult<PlateResponseDto>> Create(PlateCreateDto dto)
        {
            var plate = await _plateService.CreateAsync(dto);
            if (plate == null) return Conflict("Plate with this registration number already exists.");
            return CreatedAtAction(nameof(GetById), new { id = plate.Id }, plate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await _plateService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

    }

}
