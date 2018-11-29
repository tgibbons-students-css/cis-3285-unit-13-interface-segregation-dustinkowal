using CrudInterfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8Basis
{
    public class OrderController
    {
        private readonly IRead<Order> reader;
        private readonly ISave<Order> saver;
        private readonly IDelete<Order> deleter;

        public OrderController(IRead<Order> orderReader, ISave<Order> orderSaver, IDelete<Order> orderDeleter)
        {
            reader = orderReader;
            saver = orderSaver;
            deleter = orderDeleter;
        }

        public void CreateOrder(Order order)
        {
            saver.Save(order);
            Console.WriteLine("CreateOrder: Saving order of " + order.product);
        }

        public Order GetSingleOrder(Guid identity)
        {
            Order ord = reader.ReadOne(identity);
            Console.WriteLine("GetSingleOrder: Saving order of " + ord.product);
            return ord;
        }


        public void UpdateOrder(Order order)
        {
            saver.Save(order);
            Console.WriteLine("UpdateOrder: Saving order of " + order.product);
        }

        public void DeleteOrder(Order order)
        {
            deleter.Delete(order);
            Console.WriteLine("DeleteOrder: Delete order of " + order.product);
        }
    }
}
