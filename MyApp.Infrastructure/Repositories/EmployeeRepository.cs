using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext appDbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployeesAsync()
        {
            return await appDbContext.Employees.ToListAsync();
        }
        public async Task<EmployeeEntity?> GetEmployeeByIdAsync(Guid empId)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == empId);
        }   
        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee)
        {
            try
            {
                employee.Id = Guid.NewGuid();
                appDbContext.Employees.Add(employee);
                await appDbContext.SaveChangesAsync();
                return employee;
            }
            catch
            {
                throw;
            }
        }
        public async Task<EmployeeEntity> UpdateEmployeeAsync(Guid empId,EmployeeEntity employee)
        {
            appDbContext.Employees.Update(employee);
            await appDbContext.SaveChangesAsync();
            return employee;
        }
        public async Task<EmployeeEntity> DeleteEmployeeAsync(Guid empId)
        {
            var employee = await appDbContext.Employees.FindAsync(empId);
            if (employee != null)
            {
                employee.IsActive = false;//soft delete
                appDbContext.Employees.Update(employee);
                await appDbContext.SaveChangesAsync();
            }
            return employee!;
        }
    }
}
