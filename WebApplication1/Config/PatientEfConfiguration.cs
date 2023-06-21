using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Config
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient);
            builder.Property(e => e.IdPatient).UseIdentityColumn();
                
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Birthdata).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.ToTable(nameof(Patient));

            Patient[] patients =
            {
                new Patient {IdPatient = 1, FirstName = "Kox", LastName = "Pacjent", Birthdata = DateTime.Parse("2020-01-01")},
                new Patient {IdPatient = 2, FirstName = "Super", LastName = "Pacjent", Birthdata = DateTime.Parse("2002-01-01")},
                new Patient {IdPatient = 3, FirstName = "Niefajny", LastName = "Pacjent", Birthdata = DateTime.Parse("2019-01-01")}
            };

            builder.HasData(patients);
        }
    }
}
