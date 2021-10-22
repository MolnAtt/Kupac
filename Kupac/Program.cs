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





            foreach (var item in new List<int> { 1,5,2,3,7,1,6})
            {
                qpac.Push(item);
                Console.WriteLine(qpac);
            }


            Console.ReadKey();
        }
    }
}
