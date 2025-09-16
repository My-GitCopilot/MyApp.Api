using MediatR;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Queries
{
    #region Get Employee All
    public record GetEmployeesQueires() : IRequest<IEnumerable<EmployeeEntity>>;

    public class GetEmployeesCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeesQueires, IEnumerable<EmployeeEntity>>
    {
        public async Task<IEnumerable<EmployeeEntity>> Handle(GetEmployeesQueires request, CancellationToken cancellationToken)
        {
            var employees = await employeeRepository.GetAllEmployeesAsync();
            return employees;
        }
    }
    #endregion

    public record GetEmployeesQueiresById(Guid id):IRequest<EmployeeEntity>;

    public class GetEmployeesQueiresByIdCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeesQueiresById, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(GetEmployeesQueiresById request, CancellationToken cancellationToken)
        {
            var employees = await employeeRepository.GetEmployeeByIdAsync(request.id);
            return employees;
        }
    }
}
