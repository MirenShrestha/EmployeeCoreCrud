using EmployeeCoreCrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCoreCrud.Controllers
{
    public class LoginController : Controller
    {

        private readonly EmployeeContext _context;

        public LoginController(EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("UserId,UserName,Password")] User User)
        {
            var user = _context.User.Where(c => c.UserName == User.UserName && c.Password == User.Password).FirstOrDefault();
            if (user != null)
            {
                return Redirect("/Employee/Index");
            }
            return Redirect("/Login/Index");

        }
    }
}
