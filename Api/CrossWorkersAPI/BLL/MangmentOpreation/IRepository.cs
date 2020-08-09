using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.MangmentOpreation
{
    public interface IRepository<T> where T : class
    {

        //generic get element by the unique id
        T GetById(params object[] id);
        //get list of elements as iquerable 
        IQueryable<T> IQueryable();
        // get Iqueryable with linq expressions as conditions
        IQueryable<T> IQueryable(Expression<Func<T, bool>> predicate);
     
    }
}

