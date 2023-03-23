namespace ExampleProject.Core.Resources
{
    public class EmployeeResource
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public bool IsActive { get; set; } = true;
    }
}
