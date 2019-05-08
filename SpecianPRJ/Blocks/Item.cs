using SpecianPRJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Blocks
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public IDistribution Distribution { get; set; }
        public int NumberId { get; set; }

        public Item(string name, IDistribution distribution)
        {
            Name = name;
            Distribution = distribution;
        }

        public double LastRequestedReliability = 0D;
        public double LastRequestedTime = 0D;
    }
}
