using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModel
{
    //message view model 
    public class Message
    {
        public static string DataSaved
        {
            get { return "Data Saved"; }

        }
        public static string NoChanges
        {

            get { return "No Changes"; }
        }
        public static string Error
        {
            get { 
                return "an error occurred";
            }
        }
    }
}
