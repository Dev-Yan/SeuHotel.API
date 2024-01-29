using SeuHotel.Infrastructure.Context;
using SeuHotel.Infrastructure.Entities;
using SeuHotel.Infrastructure.Repositories.Interfaces;
using SeuHotel.Infrastructure.Services.Interfaces;
using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(SeuHotelContext context, IUserContextValidatorService userContextValidator) : base(context, userContextValidator)
        { }
    }
}