using System.ComponentModel.DataAnnotations;
using SmartPlate.Models.Enums;
namespace SmartPlate.DTOs.PlateListing
{
    public record PlateListingUpdateDto
    {
        public decimal Price { get; set; }
        public decimal TransferFee { get; set; }
        public bool IsAuction { get; set; }
        public PlateListingStatus Status { get; set; }
    }
}