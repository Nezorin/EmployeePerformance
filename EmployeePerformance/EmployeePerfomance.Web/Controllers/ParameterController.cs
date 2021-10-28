using AutoMapper;
using EmployeePerfomance.BusinessLogic.Contracts;
using EmployeePerfomance.DataAccessLayer.Entities;
using EmployeePerfomance.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EmployeePerfomance.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ParameterController : Controller
    {
        private readonly IParameterService _parameterService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public ParameterController(IParameterService parameterService, IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _parameterService = parameterService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_parameterService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _parameterService.DeleteByIdAsync(id);
            return RedirectToAction("Index", "Parameter");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ParameterViewModel parameterViewModel = new();
            parameterViewModel.Departments = _departmentService.GetAll();
            return View(parameterViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ParameterViewModel parameterViewModel)
        {
            var parameter = _mapper.Map<Parameter>(parameterViewModel);
            parameter.Department = await _departmentService.GetAll().FirstOrDefaultAsync(d => d.Id == parameterViewModel.DepartmentId);
            await _parameterService.CreateAsync(parameter);
            return RedirectToAction("Index", "Parameter");
        }
    }
}
