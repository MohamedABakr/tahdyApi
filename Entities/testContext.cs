using Microsoft.EntityFrameworkCore;
using test_Api.Models;

namespace test_Api.Entities
{
    public class testContext : DbContext  
    {
        public testContext() { }
        public testContext(DbContextOptions<testContext> options) : base(options) { }
        public DbSet<items> items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=testApi;Integrated Security=True;Encrypt=False");

            base.OnConfiguring(optionsBuilder);
        }
    }
    
    
}
