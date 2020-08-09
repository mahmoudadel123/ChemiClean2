using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModel
{

    /// <summary>
    /// the main duty of that class is to organize response that comes back from database durin crud operations 
    /// including errors / data / data not changed 
    /// </summary>
    [Serializable]
    public class DataMessage
    {
        //intial constructor
        protected DataMessage() { }
        //constructor with done flag which refere to 
        //operation commited with no errors on database (true)
        //operation rolled back due to an error ( false)
        public DataMessage(bool _IsDone)
        {
            IsDone = _IsDone;
        }
        //constructor with done flag and message which refere to 
        //operation commited with no errors on database (true)
        //operation rolled back due to an error ( false)
        //both return with message if exist (information / warnning / error)
        public DataMessage(bool _IsDone, string _Message)
        {
            IsDone = _IsDone;
            Message = _Message;
        }
        //constructor with static message (data not found) in case that the returned value was null 
       
        public static DataMessage NoDataFound()
        {
            return new DataMessage(false, "No Data Found");
        }
        //done propertiy 
        public bool IsDone { get; set; }
        //(error , warnning , information ) message
        public string Message { get; set; }
        
    }

    [Serializable]
    public class DataMessage<T> : DataMessage where T : class
    {
        //constructor with data and done flag
        public DataMessage(T data, bool _IsDone = true)
        {
            Data = data;
            IsDone = _IsDone;
        }
        //constructor with data , done flag , message if exist (
        public DataMessage(T data, bool IsDone, string Message)
        {
            this.Data = data;
            this.IsDone = IsDone;
            this.Message = Message;
        }

        public T Data { get; private set; }

    }

    [Serializable]
    public class DataMessage<TParameter, TResult> : DataMessage
    {
        public DataMessage(TParameter parameter)
        {
            Parameter = parameter;
        }
        public TParameter Parameter { get; set; }
        public TResult Data { get; set; }

    }
}
