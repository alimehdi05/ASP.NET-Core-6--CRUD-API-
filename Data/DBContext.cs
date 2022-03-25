using Microsoft.EntityFrameworkCore;
using MVC1.Models;

namespace MVC1.Data
{
    public class DBContext :DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
