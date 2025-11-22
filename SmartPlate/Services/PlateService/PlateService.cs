using Microsoft.EntityFrameworkCore;
using SmartPlate.Data;
using SmartPlate.DTOs.Plate;
using SmartPlate.Models;
using SmartPlate.Mappers;


namespace SmartPlate.Services.PlateService
{
    public class PlateService : IPlateService
    {
        private readonly AppDbContext _context;

        // Constructor with dependency injection
        public PlateService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<PlateResponseDto?> CreateAsync(PlateCreateDto dto)
        {
            var exists = await _context.Plates
                .AnyAsync(p => p.RegistrationNumber.ToLower() == dto.RegistrationNumber.ToLower());

            if (exists) return null;

            var plate = Plate.Create(
            dto.RegistrationNumber,
            dto.Type,
            dto.Region,
            dto.YearIssued,
            dto.CanApplyToAnyVehicle,
            dto.IsAssigned,
            dto.AvailableAsCertificate,
            dto.Supply,
            dto.Categories
        );

            _context.Plates.Add(plate);
            await _context.SaveChangesAsync();

            return plate.ToDto();
        }

        public async Task<PlateResponseDto?> GetByIdAsync(Guid id)
        {
            var plate = await _context.Plates.FirstOrDefaultAsync(p => p.Id == id);
            return plate?.ToDto();
        }

        public async Task<List<PlateResponseDto>> GetAllAsync()
        {
            var plates = await _context.Plates.ToListAsync();
            return plates.Select(p => p.ToDto()).ToList();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var plate = await _context.Plates.FirstOrDefaultAsync(p => p.Id == id);
            if (plate == null) return false;

            _context.Plates.Remove(plate);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<PlateResponseDto?> UpdateAsync(PlateUpdateDto dto)
        {
            var plate = await _context.Plates.FirstOrDefaultAsync(p => p.Id == dto.Id);
            if (plate == null) return null;

            if (!string.IsNullOrWhiteSpace(dto.RegistrationNumber))
                plate.UpdateRegistrationNumber(dto.RegistrationNumber);

            if (dto.Type.HasValue)
                plate.UpdateType(dto.Type.Value);

            if (dto.Categories != null && dto.Categories.Any())
                plate.UpdateCategories(dto.Categories);

            if (!string.IsNullOrWhiteSpace(dto.Region))
                plate.UpdateRegion(dto.Region);

            if (dto.YearIssued.HasValue)
                plate.UpdateYearIssued(dto.YearIssued);

            if (dto.CanApplyToAnyVehicle.HasValue)
                plate.UpdateCanApplyToAnyVehicle(dto.CanApplyToAnyVehicle.Value);

            if (dto.IsAssigned.HasValue)
                plate.UpdateIsAssigned(dto.IsAssigned.Value);

            if (dto.AvailableAsCertificate.HasValue)
                plate.UpdateAvailableAsCertificate(dto.AvailableAsCertificate.Value);

            if (dto.Supply.HasValue)
                plate.UpdateSupply(dto.Supply.Value);

            await _context.SaveChangesAsync();
            return plate.ToDto();
        }

    }

}