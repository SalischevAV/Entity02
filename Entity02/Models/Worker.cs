using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity02.Models
{
    public class Worker
    {
        public int Id { set; get; }
        public  string Name { set; get; }
        public  string Surname { set; get; }
        public  int Age { set; get; }

        public  virtual int? CompanyId { set; get; }

        public  virtual Company Company { set; get; }

        public virtual ICollection<Hobby> Hobbyes { set; get; }
    }
}