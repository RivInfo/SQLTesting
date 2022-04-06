using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPiSLab1
{
    public abstract class DistributionLaw
    {
        protected Random _rand = new Random();

        public abstract double Next();
    }
}
