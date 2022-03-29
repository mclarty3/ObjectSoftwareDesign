using System;

namespace HW_2021_OOP
{
    static class Constants
    {
        public const double AccRate = 3.5;          // Acceleration rate for cars in m/s
        public const double AccRateEmpty = 2.5;     // Acceleration rate for light trucks in m/s
        public const double AccRateFull = 1.0;      // Acceleration rate for heavy trucks in m/s
        public const double DecRate = 7.0;          // Braking rate for cars in m/s
        public const double DecRateEmpty = 5.0;     // Braking rate for light trucks in m/s
        public const double DecRateFull = 2.0;      // Braking rate for light trucks in m/s
        public const double MpsToMph = 2.237;
        public const double MpsToKph = 3.6;
        public const double MetersToMiles = 0.000621371;
        public const double MetersToKm = 0.001;
        public const int CharMapSize = 40;
        public const double WorldSize = 200.0;
    }
}