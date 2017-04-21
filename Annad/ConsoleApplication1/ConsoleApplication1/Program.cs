
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime y = new DateTime(2016, 2, 28);
            Console.WriteLine(y);
            y = y.AddDays(1);
            Console.WriteLine(y);
            Console.ReadLine();
        }
    }
}
