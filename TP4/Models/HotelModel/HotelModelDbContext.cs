using Microsoft.EntityFrameworkCore;
using WL_TP4.Models.HotelModel;

namespace WL_TP4.Models.HotelModel
{
    public class HotelModelDbContext: DbContext
    {
        public HotelModelDbContext(DbContextOptions<HotelModelDbContext> options) : base(options) { }

        public virtual DbSet<Hotel> HotelSet { get; set; }
        public DbSet<WL_TP4.Models.HotelModel.Appreciation> Appreciation { get; set; } = default!;

    }
}
