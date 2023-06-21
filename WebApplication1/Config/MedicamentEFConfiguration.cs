using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Config
{
    public class MedicamentEFConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => new { e.IdMedicament });
            builder.Property(e => e.IdMedicament).UseIdentityColumn();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Type).IsRequired().HasMaxLength(100);

            builder.ToTable(nameof(Medicament));

            Medicament[] medicaments =
            {
                new Medicament {IdMedicament = 1, Name = "Kaszelx", Description = "Na Kaszel", Type = "Syrop"},
                new Medicament {IdMedicament = 2, Name = "Brzuszex", Description = "Na Brzuch", Type = "Tabletka"},
                new Medicament {IdMedicament = 3, Name = "Apap", Description = "Na Wszystko", Type = "Tabletka"}
            };

            builder.HasData(medicaments);
        }
    }
}
