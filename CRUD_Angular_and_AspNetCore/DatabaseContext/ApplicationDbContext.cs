using CRUD_Angular_and_AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Angular_and_AspNetCore.DatabaseContext
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{ }
		public virtual DbSet<StudentEntity> students { get; set; }
	}
}
