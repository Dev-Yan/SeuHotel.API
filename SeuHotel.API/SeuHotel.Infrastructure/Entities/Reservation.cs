using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Entities;

public class Reservation : BaseEntity
{
    public long PersonId { get; set; }
    public long HotelId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int? NumberOfGuests { get; set; }

    public Person Person { get; set; }
    public Hotel Hotel { get; set; }
}