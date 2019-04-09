using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecianPRJ.Blocks;
using SpecianPRJ.Distributions;

namespace SpecianPRJ.Tests.Distributions
{
    [TestClass]
    public class TestDiagramDrawing
    {
        [TestMethod]
        public void Should_has_correctly_connected_blocks()
        {
            var blocks = new List<Block>();

            var a1 = new Block();
            var bc2 = new Block();
            var e1 = new Block();
            var fgh3 = new Block();
            var i1 = new Block();
            var jk2 = new Block();
            var m1 = new Block();

            blocks.Add(a1);
            blocks.Add(bc2);
            blocks.Add(e1);
            blocks.Add(fgh3);
            blocks.Add(i1);
            blocks.Add(jk2);
            blocks.Add(m1);

            var dist1 = new ExponencialDistribution(1 / 1000000D);  //10e-6

            var a = new Item("Item ", dist1);
            var b = new Item("Item ", dist1);
            var c = new Item("Item ", dist1);

            var e = new Item("Item ", dist1);

            var f = new Item("Item ", dist1);
            var g = new Item("Item ", dist1);
            var h = new Item("Item ", dist1);

            var i = new Item("Item ", dist1);

            var j = new Item("Item ", dist1);
            var k = new Item("Item ", dist1);

            var m = new Item("Item ", dist1);

            a1.Add(a);
            bc2.Add(b);
            bc2.Add(c);
            e1.Add(e);
            jk2.Add(j);
            jk2.Add(k);
            i1.Add(i);
            fgh3.Add(f);
            fgh3.Add(g);
            fgh3.Add(h);
            m1.Add(m);
        }
    }
}
