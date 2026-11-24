using System.ComponentModel.DataAnnotations;

namespace SmartCampusPortal.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public string StudentName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? ServiceType { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}