using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class AddressViewModel:IEnumerable
    {
        public List<Address>dropOffs { get; set; }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in dropOffs)
            {
                yield return item;
            }
        }
    }
}