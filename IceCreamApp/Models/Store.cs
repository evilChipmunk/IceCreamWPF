using System.Collections.Generic;

namespace IceCreamApp.Models
{
    public class Store : BaseEntity
    {
        public Store()
        { 
            IceCreams = new HashSet<IceCream>();
        }
        public Address Address { get; set; }

   
        public long? AddressId { get; set; }
         
      //  public Stock InStock { get; set; }

        public virtual ICollection<IceCream> IceCreams { get; set; }

        public string ManagerName { get; set; } 

        public string Phone { get; set; }

        public string StoreName { get; set; }

        public string OperationalStatus { get; set; }
    }
}