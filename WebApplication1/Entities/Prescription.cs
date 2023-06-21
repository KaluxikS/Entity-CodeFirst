using System.Data;
using WebApplication1.Migrations;

namespace WebApplication1.Entities
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataDue { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public virtual Doctor doctor { get; set; }
        public virtual Patient patient { get; set; }
        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; } = new List<Prescription_Medicament>();
    }
}
