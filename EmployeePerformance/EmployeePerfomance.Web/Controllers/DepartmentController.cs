using AutoMapper;
using EmployeePerfomance.BusinessLogic.Contracts;
using EmployeePerfomance.DataAccessLayer.Entities;
using EmployeePerfomance.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Departments()
        {
            return View(_departmentService.GetAll().ToList());
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentViewModel model)
        {
            var newUser = _mapper.Map<Department>(model);
            await _departmentService.CreateAsync(newUser);
            return RedirectToAction("Departments");
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            await _departmentService.RemoveByIdAsync(id);
            return RedirectToAction("Departments");
        }
        public async Task<JsonResult> CheckDepartment(string departmentName)
        {
            var department = await _departmentService.GetAll().FirstOrDefaultAsync(d => d.DepartmentName == departmentName);
            if (department is not null)
                return Json(false);
            return Json(true);
        }
    }
}
