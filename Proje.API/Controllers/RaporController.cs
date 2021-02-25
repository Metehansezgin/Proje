using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.API.Models;
using Proje.Business.Concrete;

namespace Proje.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        IletisimManager im = new IletisimManager();

        
        [HttpGet("kisi_sayisi/{konum}")]
        public IActionResult kisiSayisi(string konum)
        {
            Dictionary<String, int> Result = new Dictionary<string, int>();
            Result.Add(konum, im.GetList(x => x.Konum == konum).Count);
           return new JsonResult(Result);;
        }

        [HttpGet("telefon_sayisi/{telefon}")]
        public IActionResult telefonSayisi(string telefon)
        {
            Dictionary<String, int> Result = new Dictionary<string, int>();
            Result.Add(telefon, im.GetList(x => x.Telefon == telefon).Count);
            return new JsonResult(Result); ;
        }

    }
}