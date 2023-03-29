using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class workexprence
    {
        public int id { get; set; }
        public string companyname { get; set; }
        public string jobtitle { get; set; }
        public string joblocation { get; set; }
        public string jobdescription { get; set; }
        public string jobstariingfrom { get; set; }
        public DateTime jobstartingfrom { get; set; }
        public string jobendingfrom { get; set; }
        public int employee_id { get; set; }

        public string jobstartingmonth { get; set; }
        public string jobstartingyear { get; set; }
        public string jobendingmonth { get; set; }
        public string jobendingyear { get; set; }
    }
}