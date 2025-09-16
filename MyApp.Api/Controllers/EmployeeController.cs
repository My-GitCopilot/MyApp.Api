using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Queries;
using MyApp.Core.Entities;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employee)
        {

            var result = await sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid id, [FromBody] EmployeeEntity employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Employee ID mismatch");
            }
            var result = await sender.Send(new UpdateEmployeeCommand(employee));
            return Ok(result);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await sender.Send(new GetEmployeesQueires());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEmployeesByIdAsync(Guid id)
        {
            var result = await sender.Send(new GetEmployeesQueiresById(id));
            return Ok(result);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid id)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
    }
}
