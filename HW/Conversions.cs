using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2021_OOP
{
    static class Conversions
    {
        public static int WCpointToCCpoint(double val, double maxWorldSize = Constants.WorldSize)
        {
            return (int)(val * (Constants.CharMapSize / maxWorldSize) + (Constants.CharMapSize / 2));
        }

        public static int WClengthToCClength(double val, double maxWorldSize = Constants.WorldSize)
        {
            return (int)(val * (Constants.CharMapSize / maxWorldSize));
        }
    }
}

/*

200 mi x 200 mi
40 x 40 chars map

50 mi = 10 chars + 20 = 30 chars

*/