using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class ApplicationUser_IndexViewModel : IEnumerable
    {
        public ApplicationUser appUser { get; set; }
        public IndexViewModel indexVM { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}