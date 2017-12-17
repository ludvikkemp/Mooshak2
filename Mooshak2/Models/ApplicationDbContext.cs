using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2.Models.Entities;

namespace Mooshak2.Models
{
	
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Course> Courses { get; set; }
		public DbSet<Assignment> Assignments { get; set; }
		public DbSet<Milestone> Milestones { set; get; }
		public DbSet<Submission> Submissions { get; set; }

		public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}