using ExampleProject.Core.Models;

namespace ExampleProject.Core.Repository
{
    public partial interface IDataRepository
    {
        Task<Employee?> GetEmployeeById(int id);

        Task<int> AddEmployee(Employee employee);

        Task<int> UpdateEmployee(Employee employee);

        Task<int> DeleteEmployee(int employeeId);
    }
}
