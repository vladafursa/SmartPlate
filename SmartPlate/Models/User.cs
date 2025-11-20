using System;
using System.Collections.Generic;
using SmartPlate.Models.Enums;

namespace SmartPlate.Models;

//class representing system user
public class User
{
    // Private parameterless constructor required by EF Core.
    private User() { }
    //private constructor to prevent direct instantiation with "new"
    private User(Guid id, string userName, string passwordHash, string email, string role)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
        Role = role;

        OrdersAsBuyer = new List<Order>();
        OrdersAsSeller = new List<Order>();
        Bids = new List<PlateBid>();
        OwnershipHistory = new List<PlateOwnershipRecord>();
    }

    // // Unique identifier
    public Guid Id { get; set; }

    //Publicly readable, but only settable inside this class.
    public string UserName { get; private set; } = null!;

    public string PasswordHash { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    // Role property with default user role
    public string Role { get; private set; } = "User";

    public ICollection<Order> OrdersAsBuyer { get; private set; } = new List<Order>();
    public ICollection<Order> OrdersAsSeller { get; private set; } = new List<Order>();
    public ICollection<PlateBid> Bids { get; private set; } = new List<PlateBid>();
    public ICollection<PlateOwnershipRecord> OwnershipHistory { get; private set; } = new List<PlateOwnershipRecord>();


    // method for creating a new user instance.
    public static User Create(Guid id, string userName, string passwordHash, string email, string role = "User")
    {
        return new User(id, userName, passwordHash, email, role);
    }

    public void AddOrderAsBuyer(Order order) => OrdersAsBuyer.Add(order);
    public void AddOrderAsSeller(Order order) => OrdersAsSeller.Add(order);
    public void AddBid(PlateBid bid) => Bids.Add(bid);
    public void AddOwnershipRecord(PlateOwnershipRecord record) => OwnershipHistory.Add(record);
}
