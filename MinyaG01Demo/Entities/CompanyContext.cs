using Microsoft.EntityFrameworkCore;
using MinyaG01Demo.Models;

namespace MinyaG01Demo.Entities
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() { }
        public CompanyContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Student { get; set; }
    }
}
