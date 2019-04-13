using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Interfaces
{
    public interface IBlock
    {
        List<IBlock> InputBlocks { get; set; }
        List<IBlock> OutputBlocks { get; set; }
        List<IItem> ParalelItems { get; set; }
    }
}
