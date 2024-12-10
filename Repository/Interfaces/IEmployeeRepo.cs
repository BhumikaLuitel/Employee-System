using ProductApp.Entities;

namespace ProductApp.Repository.Interfaces;

public interface IEmployeeRepo
{
    Task<List<Employee>> GetAll();            
    Task<Employee> GetById(int id);
}