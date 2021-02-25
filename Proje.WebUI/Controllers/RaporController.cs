using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Proje.WebUI.Controllers
{
    public class RaporController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}