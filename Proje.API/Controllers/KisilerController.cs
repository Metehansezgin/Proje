using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.Business.Concrete;
using Proje.Entities;

namespace Proje.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
   
    [ApiController]
    public class KisilerController : ControllerBase
    {
        KisilerManager km = new KisilerManager();
        IletisimManager im = new IletisimManager();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet("getList")]
        public IActionResult GetList()
        {
            return new JsonResult(km.GetList()); 
        }

        [HttpGet("get/{id}")]
        public String Get(int id)
        {             
            Kisiler temp = km.Get(id);
            //  List<Iletisim> iletisimtemp = im.GetList(x=>x.KID==temp.UUID);

            return JsonSerializer.Serialize(temp);// JsonSerializer.Serialize(iletisimtemp);
        }

        [HttpGet("getUserDetial/{id}")]
        public String GetUserDetial(int id)
        {
            Kisiler temp = km.Get(id);
            //  List<Iletisim> iletisimtemp = im.GetList(x=>x.KID==temp.UUID);
            Dictionary<String, Object> result =new Dictionary<string, object>();
            result.Add("Kisi", temp);
            List<Iletisim> list = im.GetList(x => x.KID == id);
            if(list.Count>0)
                result.Add("Iletisim", list);

            return JsonSerializer.Serialize(result);// JsonSerializer.Serialize(iletisimtemp);
        }

        [HttpPost("add")]
        public IActionResult KisiEkle([FromBody]Kisiler kisi)
        {
           return new JsonResult(km.Add(kisi));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult KisiSil(int id)
        {
            return new JsonResult(km.Delete(km.Get(id)));
        }
        [HttpPut("update")]
        public IActionResult KisiGuncelle([FromBody] Kisiler kisi)
        {
            return new JsonResult(km.Update(kisi));
        }


    }
}