using WebApiCore.V1.DeviceRequestment.Models;

namespace WebApiCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Requestment> Requestments { get; set; }
        public DbSet<RequestmentItem> RequestmentItems { get; set; }
    }
}
