using System.ComponentModel.DataAnnotations;

namespace APARTEMENT_VISIT_MANAGEMENT_SYS.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? UserPassword { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? ContactNum { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? RegDate { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Role { get; set; }

    }
}
