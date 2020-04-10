using Ordering.DataContext.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DataContext
{
    class Program
    {
        static void Main(string[] args)
        {
            //test data
            using (var context = new OrderingContext())
            {
                var data = context.Users.ToList();
                Console.WriteLine("users retrieved");
            }
        }
    }
}
