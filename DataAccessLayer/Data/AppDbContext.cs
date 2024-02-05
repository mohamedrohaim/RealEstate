using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace DataAccessLayer.Data
{
	public class AppDbContext : DbContext{
		public AppDbContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)

		{
			base.OnModelCreating(modelBuilder);

		}


		public DbSet<UnitType> unitTypes { get; set; }	
	}
}
