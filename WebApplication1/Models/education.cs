using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class education
    {
        public int id { get; set; }
        public string collagename { get; set; }
        public string description { get; set; }
        public DateTime startingfrom { get; set; }
        public string stariingfrom { get; set; }
        public string endingfrom { get; set; }
        public int employee_id { get; set; }
        public string startingmonth { get; set; }
        public string startingyear { get; set; }

        public string endingmonth { get; set; }
        public string endingyear{ get; set; }
    
    }
}