using Microsoft.EntityFrameworkCore;

namespace Autobazar.Models;

public class CarsContext : DbContext
{
    public CarsContext(DbContextOptions options) : base(options) { }
    public DbSet<Car> Cars { get; set; }
}
