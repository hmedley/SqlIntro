using System;
using System.Linq;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=LocalHost;Database=adventureworks;Uid=root;Pwd=hrm032300;"; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new ProductRepository(connectionString);
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name + " DateModified: " + prod.ModifiedDate.DayOfWeek);
            }
            
           
            Console.ReadLine();
        }

       
    }
}
