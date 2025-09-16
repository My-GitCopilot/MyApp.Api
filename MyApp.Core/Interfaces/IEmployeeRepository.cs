using MyApp.Core.Entities;

namespace MyApp.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetAllEmployeesAsync();
        Task<EmployeeEntity?> GetEmployeeByIdAsync(Guid empId);
        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee);
        Task<EmployeeEntity> UpdateEmployeeAsync(Guid empId, EmployeeEntity employee);
        Task<EmployeeEntity> DeleteEmployeeAsync(Guid empId);
    }
}
