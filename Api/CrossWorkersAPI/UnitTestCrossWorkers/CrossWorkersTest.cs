using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DAL;
using BLL.MangmentOpreation;
using BLL.Business;
using CrossWorkersAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestCrossWorkers
{
    [TestClass]
    public class CrossWorkersTest
    {
        #region  test unit of work 
        /// <summary>
        /// check get all funtion 
        /// </summary>
        [TestMethod]
        public void TestUnitOFWorkGetAll()
        {
            //connect to our local database 
            var options = new DbContextOptionsBuilder<crossoverContext>()
            .UseSqlServer("Server=.;Database=crossover;Trusted_Connection=True;")
            .Options;
            using (var context = new crossoverContext(options))
            {
                UnitOfWork UnitOfWork = new UnitOfWork(context);
                var products = UnitOfWork.ProductRepository.IQueryable();
                //check if data is not null
                Assert.IsNotNull(products);
            }

        }
        /// <summary>
        /// check get by id function
        /// </summary>
        [TestMethod]
        public void TestUnitOFWorkGetById()
        {

            var options = new DbContextOptionsBuilder<crossoverContext>()
            .UseSqlServer("Server=.;Database=crossover;Trusted_Connection=True;")
            .Options;
            using (var context = new crossoverContext(options))
            {
                UnitOfWork UnitOfWork = new UnitOfWork(context);
                for (int i = 1; i <= 100; i++)
                {
                    var products = UnitOfWork.ProductRepository.GetById(i);
                    //check if data is not null
                    Assert.IsNotNull(products);
                }
            }

        }
        #endregion

        #region  test APIs
        /// <summary>
        /// test get all api 
        /// </summary>
        [TestMethod]
        public void TestAPIGetAll()
        {

            var options = new DbContextOptionsBuilder<crossoverContext>()
            .UseSqlServer("Server=.;Database=crossover;Trusted_Connection=True;")
            .Options;
            using (var context = new crossoverContext(options))
            {
                //get object of unit of work
                UnitOfWork UnitOfWork = new UnitOfWork(context);
                //mock object of bal_products
                var mock = new Mock<BAL_Products>(UnitOfWork);
                
                ProductsController Product = new ProductsController(mock.Object);
                Task<JsonResult> result = Product.GetProducts();
                //test if result is not null
                Assert.IsNotNull(result);
            }

        }
        /// <summary>
        /// test save files locally
        /// </summary>
        [TestMethod]
        public void TestAPISaveLocal()
        {
            var options = new DbContextOptionsBuilder<crossoverContext>()
            .UseSqlServer("Server=.;Database=crossover;Trusted_Connection=True;")
            .Options;
            using (var context = new crossoverContext(options))
            { 
                //get object of unit of work
                UnitOfWork UnitOfWork = new UnitOfWork(context);
                //test if result is not null
                var mock = new Mock<BAL_Products>(UnitOfWork);
                //check all local files just in case id is in sequance from 1 to 100 
                //must be updated if id is different
                ProductsController Product = new ProductsController(mock.Object);
                for (int i = 1; i <= 100; i++)
                {
                    Task<JsonResult> result = Product.SaveLocal(i);
                    //check if result is not null
                    Assert.IsNotNull(result);
                }

            }

        }
      /// <summary>
      /// test check version
      /// </summary>
        [TestMethod]
        public void TestAPICheckVersion()
        {
            var options = new DbContextOptionsBuilder<crossoverContext>()
            .UseSqlServer("Server=.;Database=crossover;Trusted_Connection=True;")
            .Options;
            using (var context = new crossoverContext(options))
            {
                //get object of unit of work
                UnitOfWork UnitOfWork = new UnitOfWork(context);
                //test if result is not null

                var mock = new Mock<BAL_Products>(UnitOfWork);
                ProductsController Product = new ProductsController(mock.Object);
                JsonResult result = Product.CheckVersion();
                //check if result is not null
                Assert.IsNotNull(result);

            }

        }
        #endregion
    }
}
