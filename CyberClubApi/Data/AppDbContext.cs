using Microsoft.EntityFrameworkCore;
using CyberClubApi.Models;

namespace CyberClubApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Цей рядок створює таблицю "Computers" у базі даних
        public DbSet<Computer> Computers { get; set; }
    }
}