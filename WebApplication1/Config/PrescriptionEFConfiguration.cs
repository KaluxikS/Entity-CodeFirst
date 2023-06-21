using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Config
{
    public class PrescriptionEFConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => new { e.IdPrescription });

            builder.Property(e => e.Data).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DataDue).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.HasOne(e => e.doctor)
                    .WithMany(e => e.Prescriptions)
                    .HasForeignKey(e => e.IdDoctor)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.patient)
                    .WithMany(e => e.Prescriptions)
                    .HasForeignKey(e => e.IdPatient)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Prescription");

            Prescription[] prescriptions =
            {
                new Prescription { IdPrescription = 1, Data = DateTime.Parse("2023-05-15"), DataDue = DateTime.Parse("2023-05-30"), IdDoctor = 1, IdPatient = 1 },
                new Prescription { IdPrescription = 2, Data = DateTime.Parse("2023-05-15"), DataDue = DateTime.Parse("2024-05-30"), IdDoctor = 2, IdPatient = 2 },
            };

            builder.HasData(prescriptions);
        }
    }
}
