using EFMVCDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFMVCDemo.Context
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
