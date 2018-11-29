using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {

        public Order(string product, int amount, Guid id)
        {
            this.product = product;
            this.amount = amount;
        }
        //TEG added
        public Guid id { get; set; }
        public string product { get; set; }
        public int amount { get; set; }

        //sets object info toString #1
        public string toString()
        {
            string desc;
            desc = "Order of " + amount + " " + product + " with " + id;

            return desc;
        }
    }
}
