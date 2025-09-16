using System.ComponentModel.DataAnnotations;

namespace MyApp.Core.Entities
{
    public class EmployeeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Email { get; set; } 

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? Dob { get; set; }

        public DateOnly? Doj { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? Updated { get; set; }

        public bool? IsActive { get; set; }
    }
}
