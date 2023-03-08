using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingSystem.Models
{
    public class Candidate
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("CandidateId", TypeName = "numeric(6,0)")]
        public decimal CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
        public string ResidentialZipCode { get; set; }
    }
}
