using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class empmodel
    {
        public int id { get; set; }
        public Nullable<int> RollNo { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}