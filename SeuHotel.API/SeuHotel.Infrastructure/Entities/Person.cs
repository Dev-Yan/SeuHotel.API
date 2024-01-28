using Shared.Core.Classes;
using Shared.Core.Enums;

namespace SeuHotel.Infrastructure.Entities;

public class Person : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public UserTypeEnum UserType { get; set; }
    public GenderEnum Gender { get; set; }
    public NationalityEnum Nationality { get; set; }

    public List<Review> Reviews { get; set; } = new List<Review>();
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<Hotel>? Hotels { get; set; } = new List<Hotel>();
}