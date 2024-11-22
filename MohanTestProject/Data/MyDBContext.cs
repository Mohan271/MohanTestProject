using Microsoft.EntityFrameworkCore;

namespace MohanTestProject.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
                   : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
