using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TrackingSystem.ViewModels
{
    public class CandidateVM
    {
        public decimal CandidateId { get; set; }
        public string EmailMessage { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(200)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Adress is required")]
        [StringLength(200)]
        [EmailAddress]
        public string EmailAdress { get; set; }
        [StringLength(15)]
        [Phone]
        public string PhoneNumber { get; set; }
        [StringLength(20)]
        public string ResidentialZipCode { get; set; }
    }
}
