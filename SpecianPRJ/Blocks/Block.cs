using SpecianPRJ.Distributions;
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

        ////computed distribution from paralel items - COMPUTED - INTERNAL SET!
        public CustomExponencialDistribution Distribution { get; internal set; }

        public Block InputBlock { get; set; }
        public Block OutputBlock { get; set; }
        public List<Block> ParalelBlocks { get; set; } = new List<Block>();

        public double LastRequestedReliability = 0D;
        public double LastRequestedTime = 0D;

        //list of paralel items
        public List<Item> ParalelItems { get; set; } = new List<Item>();

        public void AddITem(Item item)
        {
            ParalelItems.Add(item);
            this.Distribution = new CustomExponencialDistribution(this.ParalelItems.Select(i => (IDistributionWithCumulativeDF) i.Distribution).ToList(), this);
        }

        public void AddBlock(Block item)
        {
            ParalelBlocks.Add(item);
        }
    }
}
