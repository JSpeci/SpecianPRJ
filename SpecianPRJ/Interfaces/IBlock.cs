using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Interfaces
{
    public interface IBlock
    {
        List<IBlock> InputBlock { get; set; }
        IBlock OutputBlock { get; set; }
    }
}
