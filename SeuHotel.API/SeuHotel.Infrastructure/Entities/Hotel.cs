using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Entities;

public class Hotel : BaseEntity
{
    public long OwnerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int QuantityRooms { get; set; }

    public List<string> Photos { get; set; } = new List<string>();
    public List<string> Amenities { get; set; } = new List<string>();
    public List<string> Services { get; set; } = new List<string>();

    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<Review> Reviews { get; set; } = new List<Review>();
    public List<Room>? Rooms { get; set; } = new List<Room>();

    public Person Person { get; set; }
}