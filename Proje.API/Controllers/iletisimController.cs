using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.Business.Concrete;
using Proje.Entities;

namespace Proje.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class iletisimController : ControllerBase
    {
        IletisimManager im = new IletisimManager();

        [HttpGet("get/{id}")]
        public String Get(int id)
        {
            Iletisim temp = im.Get(id);
         
            return JsonSerializer.Serialize(temp); 
        }

        [HttpGet("getList")]
        public IActionResult GetList()
        {
            return new JsonResult(im.GetList());
        }

        [HttpGet("getUserList/{id}")]
        public IActionResult GetUserList(int id)
        {
            return new JsonResult(im.GetList(x=>x.KID==id));
        }

        [HttpPost("add")]
        public IActionResult IletisimEkle([FromBody]Iletisim kisi)
        {
            return new JsonResult(im.Add(kisi));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult IletisimSil(int id)
        {
            return new JsonResult(im.Delete(im.Get(id)));
        }
        [HttpPut("update")]
        public IActionResult IletisimGuncelle([FromBody] Iletisim kisi)
        {
            return new JsonResult(im.Update(kisi));
        }


        [HttpGet("rapor_kisi/{veri}")]
        public String Rapor_Kisi_Kayit_Sayisi(string veri)
        {   

            return JsonSerializer.Serialize(im.Rapor_Kisi_Kayit_Sayisi(veri));
        }

        [HttpGet("rapor_telefon/{veri}")]
        public String Rapor_Telefon_Kayit_Sayisi(string veri)
        {
            return JsonSerializer.Serialize(im.Rapor_Telefon_Kayit_Sayisi(veri));
        }


        [HttpGet("rapor_konum_list")]
        public IActionResult rapor_konum_list()
        {
            return new JsonResult(im.Konum_Liste());
             
        }

    }
}