using Shared.Core.Classes;
using Shared.Core.Enums;

namespace SeuHotel.Infrastructure.Entities;

public class Room : BaseEntity
{
    public long HotelId { get; set; }
    public RoomTypeEnum RoomType { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string RoomSize { get; set; } = string.Empty;
    public int MaxOccupancy { get; set; }
    public float Price { get; set; }

    public List<string> Photos { get; set; } = new List<string>();
    public List<string> Amenities { get; set; } = new List<string>();
    public List<string> Services { get; set; } = new List<string>();

    public Hotel Hotel { get; set; }
}