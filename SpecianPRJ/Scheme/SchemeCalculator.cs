﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Scheme
{
    public class SchemeCalculator
    {
        //params
        public double CalculateScheme(SchemeHolder scheme, double time)
        {
            double probOfScheme = 1D;
            foreach (var block in scheme.Blocks)
            {
                //calculate probability of serial items
                if(block.ParalelItems.Count > 0)
                {
                    double probabilityOfFailureOfBlock = 1D;
                    foreach (var item in block.ParalelItems)
                    {
                        probabilityOfFailureOfBlock *= (item.Distribution.CumulativeDistributionFunction(time));
                    }

                    probOfScheme *= (1 - probabilityOfFailureOfBlock);
                }
            }
            return probOfScheme;
        }
    }
}
