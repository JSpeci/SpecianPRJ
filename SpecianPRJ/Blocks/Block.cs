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
        public IDistribution Distribution { get; internal set; }

        public Block InputBlock { get; set; }
        public Block OutputBlock { get; set; }
        public List<IBlock> ParalelBlocks { get; set; }
        public List<IBlock> SerialBlocks { get; set; }

        //list of paralel items
        public List<IItem> ParalelItems { get; set; } = new List<IItem>();

        public void Add(IItem item)
        {
            ParalelItems.Add(item);
        }        
    }
}
