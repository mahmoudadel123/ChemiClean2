using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblProduct
    {
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string Url { get; set; }
        public byte[] LocalFile { get; set; }
        public int Id { get; set; }
        public DateTime? DownLoadDate { get; set; }
    }
}
