using System;

namespace SmartPlate.Models
{
    public class PlateBid
    {
        // Parameterless constructor for EF Core
        private PlateBid() { }

        // Private constructor to ensure controlled creation
        private PlateBid(PlateListing plateListing, User user, decimal amount)
        {
            Id = Guid.NewGuid();
            PlateListing = plateListing ?? throw new ArgumentNullException(nameof(plateListing));
            PlateListingId = plateListing.Id;
            User = user ?? throw new ArgumentNullException(nameof(user));
            UserId = user.Id;
            Amount = amount;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }

        // Associated listing
        public Guid PlateListingId { get; private set; }
        public PlateListing PlateListing { get; private set; } = null!;

        // User who placed the bid
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;

        // Bid details
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Factory method to create a new bid
        public static PlateBid Create(PlateListing plateListing, User user, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Bid amount must be positive", nameof(amount));
            return new PlateBid(plateListing, user, amount);
        }
    }
}
