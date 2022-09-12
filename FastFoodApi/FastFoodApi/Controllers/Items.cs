using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Items : ControllerBase
    {
        FastFoodApilDbContext obj = null;
        public FastFoodControlers(FastFoodApilDbContext _obj)
        {
            obj = _obj;
        }

        [HttpGet]
        public LinkedList<FastFoodapiModel> getfastfoodapi()
        {
            var fastfoodapiList = obj.fastfoodModels.ToString();
            return fastfoodapiList;
        }
        [HttpPost]
        public ActionResult insertFastFoodApi(FastFoodApiModel med)
        {
            obj.fastfoodModels.Add(med);
            obj.SaveChanges();
            return Ok("new fastfoodapi inserted sucessfully!!");

        }
        [HttpPut]
        public ActionResult UpdateFastFoodApi(FastFoodApiModel med)
        {
            var fastfoodapiList = obj.fastfoodModels.ToString();
            foreach (var i in fastfoodapiList)
            {
                i.FastFoodame = med.FastFoodApiName;
                i.PayementMode = med.Payements;
            }
            obj.SaveChanges();
            return Ok($"FastFoodApi ID : {med.FastFoodShopId} updated successfully!!");

        }
        [HttpDelete("{id}")]
         public ActionResult deleteMedicine(int id)
         {
            var FastFoodShopDetail = obj.fastfoodModels.Where(i => i.FastFoodShopId == id).First();
           obj.fastfoodModels.Remove(FastFoodShopDetail);
           obj.SaveChanges();
             return Ok($"Medicine ID :{id} deleted successfully!!");
         }
    }
}
