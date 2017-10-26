using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity02.Models
{
    public class Company
    {
        public int Id { set; get; }
        public string CompanyName { set; get; }
        public string CompanyLocation { set; get; }

        public virtual ICollection<Worker> Workers { set; get; }
    }
}