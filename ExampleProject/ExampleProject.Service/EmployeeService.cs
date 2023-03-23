using ExampleProject.Core.Models;
using ExampleProject.Core.Repository;
using ExampleProject.Core.Services;

namespace ExampleProject.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataRepository _dataRepository;

        public EmployeeService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _dataRepository.GetEmployeeById(id);
        }
    }
}