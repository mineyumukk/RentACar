using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:UserOperation,IEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
    }
}
