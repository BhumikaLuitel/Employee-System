using ProductApp.Models;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Repository.Interfaces;
using ProductApp.Services.Interfaces;
using ProductApp.ViewModels;

namespace ProductApp.Controllers;

public class EmployeeController : Controller
{
    
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeRepo _employeeRepo;

    public EmployeeController(IEmployeeService  employeeService, IEmployeeRepo employeeRepo) //constructor
    {
        _employeeService = employeeService;
        _employeeRepo = employeeRepo;
    }

    ///*** REPORT
    
        public async Task<IActionResult> Report()
        {
            var employees = await _employeeRepo.GetAll(); // Await the async method
            return View(employees); // Pass the resolved list to the view
        }


    ///*** CREATE
    public IActionResult Create()
    {
        var data = new EmployeeVm();
        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        var dto = new EmployeeDto()
        {
            Name = vm.Name,
            Education = vm.Education,
            Address = vm.Address,
            Email = vm.Email,
            Age = vm.Age,
            Gender = vm.Gender,
            Position = vm.Position,
            Phone = vm.Phone,
        };
        await _employeeService.Create(dto);
        return RedirectToAction("Report");
    }

    ///*** UPDATE
    public async Task<IActionResult> Update(int id)
    {
        var employee = await _employeeRepo.GetById(id);
        var vm = new EmployeeEditVm()
        {
            Id = employee.Id,
            Name = employee.Name,
            Education = employee.Education,
            Address = employee.Address,
            Email = employee.Email,
            Age = employee.Age,
            Gender = employee.Gender,
            Position = employee.Position,
            Phone = employee.Phone,
        };
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, EmployeeEditVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        var dto = new EmployeeDto()
        {
            Id = id,
            Name = vm.Name,
            Education = vm.Education,
            Address = vm.Address,
            Email = vm.Email,
            Age = vm.Age,
            Gender = vm.Gender,
            Position = vm.Position,
            Phone = vm.Phone,
        };
        await _employeeService.Update(dto);
        return RedirectToAction("Report");
    }
    ///*** DELETE
    
    public async Task<IActionResult> Delete(int id)
    {
        await _employeeService.Delete(id);
        return RedirectToAction("Report");
    }
    
   
        
        
    }

            
    


