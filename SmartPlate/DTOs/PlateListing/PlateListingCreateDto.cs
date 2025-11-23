using System.ComponentModel.DataAnnotations;
using SmartPlate.Models.Enums;
namespace SmartPlate.DTOs.PlateListing
{
    public record PlateListingCreateDto
    {
        public decimal Price { get; set; }
        public bool IsAuction { get; set; }
        public decimal TransferFee { get; set; } = 80m;
    }
}
