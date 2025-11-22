using Microsoft.EntityFrameworkCore;
using SmartPlate.Data;
using SmartPlate.DTOs.Plate;
using SmartPlate.Models;
using SmartPlate.Mappers;
using SmartPlate.Services.PlateOwnershipService;

namespace SmartPlate.Services.PlateService
{
    public interface IPlateService
    {
        Task<PlateResponseDto?> CreateAsync(PlateCreateDto dto, Guid currentUserId);
        Task<PlateResponseDto?> GetByIdAsync(Guid id);
        Task<List<PlateResponseDto>> GetAllAsync();
        Task<PlateResponseDto?> UpdateAsync(PlateUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}