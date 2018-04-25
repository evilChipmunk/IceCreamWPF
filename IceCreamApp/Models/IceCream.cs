using System;
using System.Collections.Generic;

namespace IceCreamApp.Models
{
    public class IceCream : BaseNamedEntity
    {
        public IceCream()
        {  
            Stores = new HashSet<Store>();
        }

       
        public double CreationCost { get;  set; }  

        public string ImageLink { get;   set; }    
         
        public virtual ICollection<Store> Stores { get;   set; }

    }
}