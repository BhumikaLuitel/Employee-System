using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Services.Interfaces;

public interface IEmployeeService
{
    Task<Employee> Create(EmployeeDto dto);
    Task <Employee>Update(EmployeeDto dto);
    Task Delete(int id);
}