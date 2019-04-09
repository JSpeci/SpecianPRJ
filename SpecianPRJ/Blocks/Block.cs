using SpecianPRJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Blocks
{
    /// <summary>
    /// Block can be connected in serial line
    /// Block can contain n paralel 
    /// </summary>
    public class Block : IBlock
    {
        //identifier - should be another structure
        public string Name { get; set; }

        //computed distribution from paralel items - COMPUTED - INTERNAL SET!
        public IDistribution Distribution { get; internal set; }

        //Scheme interface
        public IBlock InputBlock { get; set; }
        public IBlock OutputBlock { get; set; }

        //list of paralel items
        public List<IItem> ParalelItems { get; set; } = new List<IItem>();
        List<IBlock> IBlock.InputBlock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(IItem item)
        {
            ParalelItems.Add(item);
        }

        //List of paralel blocks
        //public List<IItem> ParalelBlocks { get; set; }
    }
}
