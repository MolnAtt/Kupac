using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kupac
{
    class Program
    {
        static void Main(string[] args)
        {
            Kupac<int> qpac = new Kupac<int>((x,y)=> x.CompareTo(y));

            foreach (var item in new List<int> { 1,5,2,3,7,1,6,6,78,2,45,5,6,2,2345,56,76,2,234,56,6,23,234,5,76,7,2,35,6,7,8})
            {
                qpac.Push(item);
                Console.WriteLine(qpac);
            }

            while (!qpac.Empty())
            {
                Console.WriteLine($"Kivettem a legnagyobb elemet, ez az: {qpac.Pop()}");
                Console.WriteLine(qpac);
            }

            Console.ReadKey();
        }
    }
}
