using Microsoft.Build.Framework;

namespace APARTEMENT_VISIT_MANAGEMENT_SYS.Models
{
    public class ApartmentModel
    {
        public int AptId { get; set; }
        [Required]
        public string? AptNum { get; set; }
        [Required]
        public string? AptBldg { get; set; }
        [Required]
        public string? AptStatus { get; set; }

    }
}
