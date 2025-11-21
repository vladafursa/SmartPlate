using SmartPlate.Models;
using SmartPlate.DTOs.Plate;

namespace SmartPlate.Mappers
{
    public static class PlateMapper
    {
        public static PlateResponseDto ToDto(this Plate plate)
        {
            return new PlateResponseDto
            {
                Id = plate.Id,
                RegistrationNumber = plate.RegistrationNumber,
                Type = plate.Type,
                Categories = plate.Categories.ToList(),
                Region = plate.Region,
                YearIssued = plate.YearIssued,
                CanApplyToAnyVehicle = plate.CanApplyToAnyVehicle,
                IsAssigned = plate.IsAssigned,
                AvailableAsCertificate = plate.AvailableAsCertificate,
                Supply = plate.Supply
            };
        }
    }
}
