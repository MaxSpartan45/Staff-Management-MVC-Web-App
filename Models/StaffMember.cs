using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EHA_Assessment.Models
{
    public class StaffMember
    {
        [Required(ErrorMessage = "Staff ID is required")]
        public int StaffId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }

        public override string ToString()
        {
            string details = $"Staff ID: {StaffId} | Full Name: {FullName} | Email: {Email} | Position: {Position} | Unit: {Unit}";
            return details;
        }
    }
}