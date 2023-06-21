using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using WebApplication1.Entities;

namespace WebApplication1.Config
{
    public class DoctorEFConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor);
            builder.Property(e => e.IdDoctor).UseIdentityColumn();

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);

            builder.ToTable(nameof(Doctor)); //entity.ToTable("Doctor")

            Doctor[] doctors =
            {
                new Doctor {IdDoctor = 1, FirstName = "Piotr", LastName = "Salamon", Email = "asdasda@gmail.com"},
                new Doctor {IdDoctor = 2, FirstName = "Krys", LastName = "Sto", Email = "asdasd@gmail.com"}
            };

            builder.HasData(doctors);
        }
    }
}
