using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.Models
{
  public  class Order
    {
        public int Id { get; set; }
        public string Costumer { get; set; }
        public string Address { get; set; }
        public DateTime delivery { get; set; }
        public string Status { get; set; }

        public string titleProduct { get; set; }
        public int nrBucati { get; set; }
        public int pretulTotal  { get; set; }


    }
}
