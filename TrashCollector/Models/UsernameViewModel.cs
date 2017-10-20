using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrashCollector.Models;

namespace TrashCollector.Models
{
    public class UsernameViewModel:IEnumerable
    {
       public List<ApplicationUser> people { get; set; }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}