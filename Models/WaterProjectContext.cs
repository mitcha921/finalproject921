using System;
using Microsoft.EntityFrameworkCore;

namespace finalproject921.Models
{
	public class WaterProjectContext :DbContext
	{
        public WaterProjectContext(DbContextOptions<WaterProjectContext> options)
           : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add any custom model configurations here
        }
    }
}

