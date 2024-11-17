using Microsoft.EntityFrameworkCore;
using dotNET_Questions.Models;

namespace dotNET_Questions.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
        }

        public DbSet<Question> Questions { get; set; }
    }
}
