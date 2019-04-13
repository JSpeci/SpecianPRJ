using SpecianPRJ.Blocks;
using SpecianPRJ.Cli.CliRender;
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

            var contentBlock = new Block();
            scheme.ContentBlock = contentBlock;


            var blockA = new Block();
            var blockB = new Block();


            contentBlock.ParalelBlocks.Add(blockA);
            contentBlock.ParalelBlocks.Add(blockB);

            ;

            Console.WriteLine(SchemeRender.RenderScheme(scheme));
            Console.ReadLine();
        }

        static Scheme generateTestData()
        {
            var scheme = new Scheme();
            scheme.Name = ("Test scheme");
            return scheme;
        }
    }
}
