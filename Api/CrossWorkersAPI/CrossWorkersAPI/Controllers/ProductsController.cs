using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.MangmentOpreation;
using DAL;
using BLL.Business;
using BLL.ViewModel;

namespace CrossWorkersAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
      
        //create instance of business logic layer for producst
        private BAL_Products BSS;
        //initialize the instance to be able to use it inside the whole controller
        public ProductsController(BAL_Products BSS)
        {
            this.BSS = BSS;
        }
        /// <summary>
        /// get all products
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/Products/Get")]
        public async Task<JsonResult> GetProducts()
        {
            DataMessage response = await BSS.GetProduct();
            return new JsonResult(response);
        }
        /// <summary>
        /// download copy if all files to local 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/Products/Savelocalversion/{Id}")]
        public async Task<JsonResult> SaveLocal(int Id)
        {
           var  response =await BSS.SaveAsLocal(Id);
            return new JsonResult(response);
        }

      /// <summary>
      /// check version updates
      /// </summary>
      /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/Products/CheckVersion")]
        public JsonResult CheckVersion()
        {
            var response = BSS.CheckVersion();
            return new JsonResult(response);
        }
    }

}
