using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.ViewModel;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.MangmentOpreation
{
    public class UnitOfWork
    {
        private readonly crossoverContext _dbContext;

        #region Repositories
        //set the model type to the repository class
        //create instance for product repository
        public IRepository<TblProduct> ProductRepository =>
             new Repository<TblProduct>(_dbContext);
        #endregion
        public UnitOfWork(crossoverContext dbContext)
        {
            _dbContext = dbContext;
        }
        //commit changes to database
        public bool Commit()
        {
            return _dbContext.SaveChanges() == 0 ? false : true;
        }
        //disbose connection 
        public void Dispose()
        {
            _dbContext.Dispose();
        }
       
        /// <summary>
        /// fire commit function and save data , return the result it datamessage view model
        /// which is created to return result / data / error messages
        /// </summary>
        /// <returns></returns>
        protected internal DataMessage SaveChange()
        {
            try
            {
                var haveChanges = Commit();
                return new DataMessage(true, haveChanges ? Message.DataSaved : Message.NoChanges);
            }
            catch (System.Exception e)
            {
                return new DataMessage(false, Message.Error + e.Message);
            }

        }
    }
}
