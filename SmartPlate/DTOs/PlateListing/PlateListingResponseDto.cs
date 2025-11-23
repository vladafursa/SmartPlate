using System;
using SmartPlate.Models.Enums;

namespace SmartPlate.DTOs.PlateListing
{
    public record class PlateListingResponseDto
    {
        // Listing data
        public Guid Id { get; init; }
        public decimal Price { get; init; }
        public decimal TransferFee { get; init; }
        public bool IsAuction { get; init; }
        public string Status { get; init; } = default!;
        public DateTime DateListed { get; init; }

        // Seller info
        public Guid SellerId { get; init; }
        public string SellerName { get; init; } = default!;
        public string SellerEmail { get; init; } = default!;

        // Plate info
        public Guid PlateId { get; init; }
        public string PlateRegNumber { get; init; } = default!;
        public PlateType Type { get; init; }
        public List<PlateCategory> Categories { get; init; } = new();

        public string Region { get; init; } = default!;
        public int? YearIssued { get; init; }

        public bool CanApplyToAnyVehicle { get; init; }
        public bool IsAssigned { get; init; }
        public bool AvailableAsCertificate { get; init; }

        public PlateSupplyType Supply { get; init; }
    }
}
