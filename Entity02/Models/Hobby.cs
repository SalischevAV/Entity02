using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity02.Models
{
    public class Hobby
    {
        public int Id { set; get; }
        public string HobbyName { set; get; }

        public virtual ICollection<Worker> Workers { set; get; }

    }
}