using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Entities;

public class Review : BaseEntity
{
    public long HotelId { get; set; }
    public long PersonId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;

    public Hotel Hotel { get; set; }
    public Person Person { get; set; }
}