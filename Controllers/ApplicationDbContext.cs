using Microsoft.EntityFrameworkCore;
using static SENSHOP2._1.Models.CarritoViewModel;

namespace SENSHOP2._1.Controllers
 
{
    using Microsoft.EntityFrameworkCore;

   

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }

}

