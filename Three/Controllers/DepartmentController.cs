using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Three.Models;
using Three.Services;

namespace Three.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private IOptions<ThreeOptions> _threeOptions;

        //可以注入自定义的配置映射类对象！！！
        public DepartmentController(IDepartmentService departmentService, IOptions<ThreeOptions> threeOptions)
        {
            _departmentService = departmentService;
            _threeOptions = threeOptions;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Index";
            var departments = await _departmentService.GetAll();

            //如果安装了Resharper，下面的View在视图文件不存在的时候，会显示成红色！！
            //return View();

            return View(departments);
        }

        //HttpGet可以不写，不写就是HttpGet
        //[HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Department";
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            if(ModelState.IsValid)
            {
                await _departmentService.Add(department);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}