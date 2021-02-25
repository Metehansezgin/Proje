using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proje.Business.Concrete;
using Proje.Entities;

namespace Proje.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            KisilerManager km = new KisilerManager();

           // km.Add(new Kisiler { Ad="metehan2", Soyad="sezgin" , Firma="stm"});

            return View();
        }
    }
}