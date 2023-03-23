using ExampleProject.Core.Models;
using ExampleProject.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Data.DataRepository
{
    public partial class DataRepository : IDataRepository
    {
        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _dbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            var entity = await _dbContext.Employees.Where(x => x.Id == employee.Id).FirstAsync();
            _dbContext.Entry(entity).CurrentValues.SetValues(employee);
            return await _dbContext.SaveChangesAsync(); 
        }
     
        public async Task<int> DeleteEmployee(int employeeId)
        {
            var entity = await _dbContext.Employees.Where(x => x.Id == employeeId).FirstAsync();
            entity.IsActive = false;
            return await _dbContext.SaveChangesAsync();
        }

    }
}
