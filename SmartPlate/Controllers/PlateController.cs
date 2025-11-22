using Microsoft.AspNetCore.Mvc;
using SmartPlate.DTOs.Plate;
using SmartPlate.Services.PlateService;
using System.Security.Claims;

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
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized("User ID not found in token.");

            var currentUserId = Guid.Parse(userIdClaim);
            var plate = await _plateService.CreateAsync(dto, currentUserId);
            if (plate == null) return Conflict("Plate with this registration number already exists.");
            return CreatedAtAction(nameof(GetById), new { id = plate.Id }, plate);
        }

        [HttpPut]
        public async Task<ActionResult<PlateResponseDto>> Update([FromBody] PlateUpdateDto dto)
        {
            var updatedPlate = await _plateService.UpdateAsync(dto);
            if (updatedPlate == null) return NotFound();
            return Ok(updatedPlate);
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
