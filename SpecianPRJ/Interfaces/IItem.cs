using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        IDistribution Distribution { get; }
    }
}
