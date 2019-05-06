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
    public class Block
    {
        //identifier - should be another structure
        public string Name { get; set; }

        //computed distribution from paralel items - COMPUTED - INTERNAL SET!
        public IDistribution ComputedDistribution { get; internal set; }

        public Block InputBlock { get; set; }
        public Block OutputBlock { get; set; }
        public List<Block> ParalelBlocks { get; set; } = new List<Block>();

        //list of paralel items
        public List<IItem> ParalelItems { get; set; } = new List<IItem>();

        public void AddITem(IItem item)
        {
            ParalelItems.Add(item);
        }

        public void AddBlock(Block item)
        {
            ParalelBlocks.Add(item);
        }
    }
}
