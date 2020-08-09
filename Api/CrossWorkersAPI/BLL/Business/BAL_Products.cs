using BLL.MangmentOpreation;
using BLL.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Business
{
    public class BAL_Products
    {
        private readonly UnitOfWork unit;
        public BAL_Products(UnitOfWork unit)
        {
            this.unit = unit;
        }
        
        /// <summary>
        /// get all products or get single if id is not null
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<DataMessage> GetProduct(int? Id = null)
        {
            if (Id.HasValue)
            {
                //get by id from repository
                var product = unit.ProductRepository.GetById(Id.Value);
                //return data message object (json formated object)
                return new DataMessage<TblProduct>(product, true);
            }
            else
            {
                //get all products
                var ListOfProducts = unit.ProductRepository.IQueryable().ToList();
                //return data message object (json formated object)
                return new DataMessage<List<TblProduct>>(ListOfProducts, true);
            }

        }

        /// <summary>
        /// save to local databasse by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<DataMessage> SaveAsLocal(int Id)
        {
            //get object to get it's url 
            var Product = unit.ProductRepository.GetById(Id);
            //connect to online file to get it's byte
            using (var client = new HttpClient())
            {
                using (var result = await client.GetAsync(Product.Url))
                {
                    //check if file found online 
                    if (result.IsSuccessStatusCode)
                    {
                        //copy the online data to the local database
                        var bytes = await result.Content.ReadAsByteArrayAsync();

                        Product.LocalFile = bytes;
                        Product.DownLoadDate = DateTime.Now;
                        return unit.SaveChange();
                    }
                    else
                        return new DataMessage(false, "File Not Found on the Website!");


                }
            }

        }
        /// <summary>
        /// check if online version is the same as local version just in case it's downloaded
        /// </summary>
        /// <returns></returns>
        public async Task<DataMessage> CheckVersion()
        {
            //start intial message
            string ChangedProducts = "those products document has been updated on website : ";
            //changes counter
            int countchanges = 0;
            //get the local files which updated or inserted in the last 3 days 
            var Products = unit.ProductRepository.IQueryable(e => e.LocalFile != null && e.DownLoadDate.Value.Date >= DateTime.Now.AddDays(-3).Date
            && e.DownLoadDate.Value.Date <= DateTime.Now.Date);
            foreach (var Product in Products)
                //connect to server to read online files
                using (var client = new HttpClient())
                {
                    using (var result = await client.GetAsync(Product.Url))
                    {
                        //check if file is exist
                        if (result.IsSuccessStatusCode)
                        {
                            var bytes = await result.Content.ReadAsByteArrayAsync();
                            //compare online file with files in database 
                            //and if it's different then update it 
                            if (bytes != Product.LocalFile)
                            {
                                Product.LocalFile = bytes;
                                //write downfile names
                                ChangedProducts += "\n " + Product.ProductName;
                                countchanges++;
                            }
                            else
                            {
                                continue;
                            }
                        }

                    }
                }
            //check if there is any changes
            if (countchanges != 0)
            {
                //return message with changed items
                return new DataMessage(true, ChangedProducts);
            }
            else
            {
                //return no changes happened
                return new DataMessage(false, "No File Changed on the website !");
            }


        }

    }

}

