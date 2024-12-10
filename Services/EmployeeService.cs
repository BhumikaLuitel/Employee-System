using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public
    class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;

    public EmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> Create(EmployeeDto dto)
    {
        var employee = new Employee()
        {
            Name = dto.Name,
            Phone = dto.Phone,
            Address = dto.Address,
            Email = dto.Email,
            Education = dto.Education,
            Age = dto.Age,
            Position = dto.Position,
            Gender = dto.Gender,
        };
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> Update(EmployeeDto dto)
    {
        var employee = await _context.Employees.FindAsync(dto.Id);
        
        employee.Name = dto.Name;
        employee.Phone = dto.Phone;
        employee.Address = dto.Address;
        employee.Email = dto.Email;
        employee.Education = dto.Education;
        employee.Age = dto.Age;
        employee.Position = dto.Position;
        employee.Gender = dto.Gender;
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
          
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
}