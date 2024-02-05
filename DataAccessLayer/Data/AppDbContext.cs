using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DataAccessLayer.Data
{
	public class AppDbContext : DbContext{
		public AppDbContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)

		{
			base.OnModelCreating(modelBuilder);

		}


		public DbSet<Models.UnitTypes> types { get; set; }
	}
}
