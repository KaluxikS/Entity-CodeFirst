using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Service
{
    public interface IHospitalDbService
    {
        public Task<ICollection<DoctorDTO>> GetDoctorsAsync();
        public Task<bool> AddDoctorAsync(DoctorDTO dto);
        public Task<bool> UpdateDoctorAsync(int id, DoctorDTO dto);

        public Task<bool> DeleteDoctorAsync(int id);
        public Task<PrescriptionDTO> getPrescriptionAsync(int id);

    }
}
