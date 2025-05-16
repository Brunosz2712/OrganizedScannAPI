// Models/Motorcycle.cs
namespace OrganizedScannApi.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Rfid { get; set; }
        public string ProblemDescription { get; set; }
        public int PortalId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime AvailabilityForecast { get; set; }

        // Adicione essas propriedades para eliminar os erros
        public string? Brand { get; set; }
        public int? Year { get; set; }
        public object Portal { get; internal set; }
    }
}
