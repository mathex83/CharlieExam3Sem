using CharlieExam3Sem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CharlieExam3Sem.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<City> Cities { get; set; }
		public DbSet<Runner> Runners { get; set; }
		//public DbSet<EventInfo> Events { get; set; }
	}
}
