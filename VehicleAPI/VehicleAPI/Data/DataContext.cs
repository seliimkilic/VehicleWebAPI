using Microsoft.EntityFrameworkCore;

namespace VehicleAPI.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
