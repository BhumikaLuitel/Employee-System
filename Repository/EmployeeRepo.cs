using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Entities;
using ProductApp.Repository.Interfaces;


namespace ProductApp.Repository;

public class EmployeeRepo : IEmployeeRepo
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetById(int id)
    {
        var employee = await _context.Employees.FindAsync(id);    
       
        return employee;
    }
}






