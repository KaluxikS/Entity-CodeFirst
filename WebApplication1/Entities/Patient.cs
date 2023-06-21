namespace WebApplication1.Entities
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdata { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; } = new List<Prescription_Medicament>();
        
    }
}
