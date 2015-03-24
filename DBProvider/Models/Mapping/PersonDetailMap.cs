using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DBProvider.Models.Mapping
{
    public class PersonDetailMap : EntityTypeConfiguration<PersonDetail>
    {
        public PersonDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.FirstName, t.LastName });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.FirstName)
                .IsRequired();

            this.Property(t => t.LastName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("PersonDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
        }
    }
}
