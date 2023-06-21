using Microsoft.EntityFrameworkCore;
using WebApplication1.Config;

namespace WebApplication1.Entities

{
    public class HospitalDbContext : DbContext
    {
        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }

        public HospitalDbContext() 
        {

        }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorEFConfiguration).Assembly);
        }
    }
}
