using SpecianPRJ.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTest();
        }

        static void MyTest()
        {
            Console.WriteLine("Test of block");


            var scheme = generateTestData();

            ;
        }

        static Scheme generateTestData()
        {
            var scheme = new Scheme();
            return scheme;
        }
    }
}
