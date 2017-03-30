using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.Models
{
   public class Product
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public int price { get; set; }
        public int stok { get; set; }
    }
}
