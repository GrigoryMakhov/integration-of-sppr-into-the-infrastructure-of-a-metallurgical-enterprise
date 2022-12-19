using Microsoft.EntityFrameworkCore;
using SCData.Models;

namespace SpecialityCatalogWebApi.Data
{
    public class StudentsDbContext: DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Direction> Directions { get; set; }

        public StudentsDbContext (DbContextOptions<StudentsDbContext> options): base (options)
        {

        }


    }
}
