using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleProject.Core.Models
{
    public class Employee : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        public string? FirstName { get; set; } = default!;

        public string? LastName { get; set; } = default!;

        public bool IsActive { get; set; } = true;


    }
}
