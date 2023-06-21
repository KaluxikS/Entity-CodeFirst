using System.Data;

namespace WebApplication1.DTOs
{
    public class PrescriptionDTO
    {
        public DateTime PresDate { get; set; }
        public DateTime PrestDueDate { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorEmail { get; set; }
        public IEnumerable<MedicamentDTO> Medicament { get; set; } = new List<MedicamentDTO>();
    }
    
}
