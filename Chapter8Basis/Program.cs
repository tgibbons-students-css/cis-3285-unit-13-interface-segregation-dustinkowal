using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrudImplementations;
using Model;

namespace Chapter8Basis
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("=========CreateSeparateServices=========");
            OrderController sep = CreateSeparateServices();

            Console.WriteLine("=========CreateSingleService=========");
            OrderController sing = CreateSingleService();

            Console.WriteLine("=========GenericController<Order>=========");
            GenericController<Order> generic = CreateGenericServices();

            //create order #1
            string name = "tacos";
            Guid id = Guid.NewGuid();
            int amount = 12;
            Order newOrder = new Order(name, amount, id);

            //#2
            sep.CreateOrder(newOrder);
            sep.DeleteOrder(newOrder);

            //#3
            sing.CreateOrder(newOrder);
            sing.DeleteOrder(newOrder);

            //#4
            generic.CreateEntity(newOrder);

            //#5
            Item item = new Item("chicken", 48);
            Console.WriteLine("=========GenericController<Item>=========");
            GenericController<Item> generic5 = CreateGenericServices1();

            //#6
            Console.WriteLine("=========GenericController<Item>=========");
            GenericController<Item> generic6 = CreateGenericItemServices();

            Console.WriteLine("Hit any key to quit");
            Console.ReadKey();
        }

        static OrderController CreateSeparateServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            return new OrderController(reader, saver, deleter);
        }

        static OrderController CreateSingleService()
        {
            var crud = new Crud<Order>();
            return new OrderController(crud, crud, crud);
        }

        static GenericController<Order> CreateGenericServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            // This must be declared using reflection...
            GenericController<Order> ctl = (GenericController<Order>)Activator.CreateInstance(typeof(GenericController<Order>), reader, saver, deleter);
            //This does not work 
            //GenericController<Order> ctl = new GenericController(reader, saver, deleter);
            return ctl;
        }

        static GenericController<Item> CreateGenericServices1()
        {
            var reader = new Reader<Item>();
            var saver = new Saver<Item>();
            var deleter = new Deleter<Item>();
            // This must be declared using reflection...
            GenericController<Item> ctl = (GenericController<Item>)Activator.CreateInstance(typeof(GenericController<Item>), reader, saver, deleter);
            //This does not work 
            //GenericController<Order> ctl = new GenericController(reader, saver, deleter);
            return ctl;
        }

        //#6
        static GenericController<Item> CreateGenericItemServices()
        {
            var reader = new Reader<Item>();
            var saver = new Saver<Item>();
            var deleter = new Deleter<Item>();

            //was not able to access
            void CreateItem(Item item)
            {
                saver.Save(item);
                Console.WriteLine("CreateOrder: Saving order of " + item.product);
            }

            //was not able to access
            void DeleteItem(Item item)
            {
                deleter.Delete(item);
                Console.WriteLine("DeleteOrder: Delete order of " + item.product);
            }
            // This must be declared using reflection...
            GenericController<Item> ctl = (GenericController<Item>)Activator.CreateInstance(typeof(GenericController<Item>), reader, saver, deleter);
            //This does not work 
            //GenericController<Order> ctl = new GenericController(reader, saver, deleter);
            return ctl;
        }
         
    }
}
