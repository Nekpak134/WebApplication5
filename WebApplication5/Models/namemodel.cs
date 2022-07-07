using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class namemodel
    {
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]

        public string userpassword { get; set; }
    }
}