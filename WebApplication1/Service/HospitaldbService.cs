using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Service
{
    public class HospitaldbService : IHospitalDbService
    {
        private readonly HospitalDbContext _context;
        public HospitaldbService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDoctorAsync(DoctorDTO dto)
        {
            var toAdd = await _context.AddAsync(new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
            });
            await _context.SaveChangesAsync();
            if (toAdd != null )
            {
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var toDelete = await _context.Doctors.FindAsync(id);

            if (toDelete == null)
            {
                return false;
            }

            var havePatients = await _context.Prescriptions.AnyAsync(e => e.IdDoctor == id);

            if (havePatients)
            {
                return false;
            }

            _context.Remove(toDelete);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<ICollection<DoctorDTO>> GetDoctorsAsync()
        {
            return await _context.Doctors.Select(e => new DoctorDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
            }).ToListAsync();
        }

        public async Task<PrescriptionDTO> getPrescriptionAsync(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);

            if (prescription == null)
            {
                return null;
            }

            PrescriptionDTO prescriptionDTO = await _context.Prescriptions.Where(e => e.IdPrescription == id).Select(
                e => new PrescriptionDTO
                {
                    PresDate = e.Data,
                    PrestDueDate = e.DataDue,
                    PatientFirstName = e.patient.FirstName,
                    PatientLastName = e.patient.LastName,
                    PatientBirthDate = e.patient.Birthdata,
                    DoctorFirstName = e.doctor.FirstName,
                    DoctorLastName = e.doctor.LastName,
                    DoctorEmail = e.doctor.Email,
                    Medicament = e.Prescription_Medicaments.Select(e => new MedicamentDTO
                    {
                        Name = e.Medicament.Name,
                        Description = e.Medicament.Description,
                        Type = e.Medicament.Type,
                        Dose = e.Dose
                    })
                }).FirstAsync();

            return prescriptionDTO;

        }

        public async Task<bool> UpdateDoctorAsync(int id, DoctorDTO dto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return false;
            }

            doctor.FirstName = dto.FirstName;
            doctor.LastName = dto.LastName;
            doctor.Email = dto.Email;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
