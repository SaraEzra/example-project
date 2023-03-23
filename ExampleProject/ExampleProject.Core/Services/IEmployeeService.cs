using ExampleProject.Core.Models;

namespace ExampleProject.Core.Services
{
    public interface IEmployeeService
    {
        Task<Employee?> GetEmployeeById(int id);

    }
}
