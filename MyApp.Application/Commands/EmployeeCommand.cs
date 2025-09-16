using MediatR;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Commands
{
    #region Add Employee
    public record AddEmployeeCommand(EmployeeEntity employeeEntity) : IRequest<EmployeeEntity>;

    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.AddEmployeeAsync(request.employeeEntity);
        }
    }
    #endregion
    #region Update Employee
    public record UpdateEmployeeCommand(EmployeeEntity employeeEntity) : IRequest<EmployeeEntity>;

    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateEmployeeAsync(request.employeeEntity.Id, request.employeeEntity);
        }
    }
    #endregion

    #region Delete Employee
    #endregion
    public record DeleteEmployeeCommand(Guid id) : IRequest<EmployeeEntity>;
    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployeeAsync(request.id);
        }
    }



}
