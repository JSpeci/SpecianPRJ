using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Scheme
{
    /// <summary>
    /// Core object represents RBD Diagram with values
    /// </summary>
    public class RBDDiagram
    {
        public SchemeCalculator SchemeCalculator { get; internal set; }
        public SchemeHolder SchemeHolder { get; internal set; }

        public RBDDiagram()
        {

        }


    }
}
