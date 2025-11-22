using System.ComponentModel.DataAnnotations;
using SmartPlate.Models.Enums;

namespace SmartPlate.DTOs.Plate
{
    public record class PlateUpdateDto
    {
        [Required]
        public required Guid Id { get; set; }

        // Core identity
        [StringLength(15, MinimumLength = 1)]
        public string? RegistrationNumber { get; set; }
        public PlateType? Type { get; set; }
        public List<PlateCategory>? Categories { get; set; }

        // Classification
        [StringLength(50)]
        public string? Region { get; set; }
        [Range(1900, 2025)]
        public int? YearIssued { get; set; }

        // DVLA rules
        public bool? CanApplyToAnyVehicle { get; set; }
        public bool? IsAssigned { get; set; }
        public bool? AvailableAsCertificate { get; set; }

        public PlateSupplyType? Supply { get; set; }
    }
}
