using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Config
{
    public class Prescription_MedicamentEFConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {
            builder.HasKey(e => new
            {
                e.IdMedicament,
                e.IdPrescription
            });

            builder.Property(e => e.Dose);
            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Medicament)
                .WithMany(e => e.Prescription_Medicaments)
                .HasForeignKey(e => e.IdMedicament)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Prescription)
                .WithMany(e => e.Prescription_Medicaments)
                .HasForeignKey(e => e.IdPrescription)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Prescription_Medicament");

            Prescription_Medicament[] prescription_Medicaments =
            {
                new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 2, Details = "Bierz raz dziennie" },
                new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "Bierz dwa razy dziennie" },
                new Prescription_Medicament { IdMedicament = 1, IdPrescription = 2, Dose = 15, Details = "Bierz dwa razy na godzine" }
            };

            builder.HasData(prescription_Medicaments);
        }
    }
}
