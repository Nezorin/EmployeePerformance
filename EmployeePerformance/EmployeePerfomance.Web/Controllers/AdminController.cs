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
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IStatusService _statusService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public AdminController(IUserService userService, IRoleService roleService, IStatusService statusService, IDepartmentService departmentService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _statusService = statusService;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Users()
        {
            return View(_userService.GetAll().ToList());
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            var newUser = _mapper.Map<User>(model);
            await _userService.CreateAsync(newUser);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            var model = new RegisterUserViewModel()
            {
                Roles = _roleService.GetAll().ToList(),
                Departments = _departmentService.GetAll().ToList(),
                Statuses = _statusService.GetAll().ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var userToEdit = await _userService.GetAll().FirstOrDefaultAsync(u => u.Id == model.Id);
            //Check if login wasn't changed or was changed on one that already exist
            if (userToEdit.Login == model.Login ||
                    _userService.GetAll().FirstOrDefault(t => t.Login == model.Login) == null)
            {
                var editedUser = _mapper.Map(model, userToEdit);
                await _userService.UpdateAsync(editedUser);
                return RedirectToAction("Users");
            }
            else
            {
                ModelState.AddModelError("Login", "User with such login is already exist");
                var editModel = CreateEditViewModel(userToEdit);
                return View(editModel);
            }
        }
        [HttpGet]
        public IActionResult EditUser(Guid id)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            var model = CreateEditViewModel(user);
            return View(model);
        }
        [HttpPost]
        public EditUserViewModel CreateEditViewModel(User user)
        {
            var model = _mapper.Map<EditUserViewModel>(user);
            model.Roles = _roleService.GetAll().ToList();
            model.Departments = _departmentService.GetAll().ToList();
            model.Statuses = _statusService.GetAll().ToList();
            return model;
        }
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteByIdAsync(id);
            return RedirectToAction("Users");
        }
        public async Task<JsonResult> CheckLogin(string login)
        {
            var user = await _userService.GetByLoginAsync(login);
            if (user is not null)
                return Json(false);
            return Json(true);
        }
    }
}
