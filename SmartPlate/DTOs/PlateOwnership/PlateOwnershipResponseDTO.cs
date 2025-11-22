using System;

namespace SmartPlate.DTOs.PlateOwnership
{
    public record class PlateOwnershipResponseDto
    {
        public Guid Id { get; set; }
        public Guid PlateId { get; set; }
        public string PlateRegNumber { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerUserName { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
