using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Scheme
{
    public class SchemeCalculator
    {
        //params
        public void CalculateScheme(SchemeHolder scheme, double time)
        {
            foreach(var block in scheme.Blocks)
            {
                //calculate probability of serial items

                foreach(var item in block.ParalelItems)
                {

                    //calculate probablity from paralel items
                }
            }
        }
    }
}
