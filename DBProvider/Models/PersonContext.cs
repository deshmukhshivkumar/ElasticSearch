using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DBProvider.Models.Mapping;

namespace DBProvider.Models
{
    public partial class PersonContext : DbContext
    {
        static PersonContext()
        {
            Database.SetInitializer<PersonContext>(null);
        }

        public PersonContext()
            : base("Name=PersonContext")
        {
        }

        public DbSet<PersonDetail> PersonDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonDetailMap());
        }
    }
}
