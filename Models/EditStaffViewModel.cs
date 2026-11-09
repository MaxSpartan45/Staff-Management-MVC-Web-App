using System.ComponentModel.DataAnnotations;

namespace EHA_Assessment.Models
{
    public class EditStaffViewModel
    {
        [Required(ErrorMessage = "Staff ID is required")]
        public int StaffId { get; set; }
        public string? FullName { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Position { get; set; } = "";
        public string? Unit { get; set; } = "";
    }
}