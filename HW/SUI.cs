using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2021_OOP
{
    class CharMatrix
    {
        public char[][] map = new char[Constants.CharMapSize][];

        public CharMatrix()
        {
            for (int i = 0; i < Constants.CharMapSize; i++)
            {
                map[i] = new char[Constants.CharMapSize];
                for (int j = 0; j < Constants.CharMapSize; j++) map[i][j] = ' ';
            }
        }
    }

    public interface IPrintDriver
    {
        void PrintRoad(Road road, Object o);
        void PrintCar(Car car, Object o);
        void PrintRoadItem(RoadItem roadItem, Object o, GUI gui);
    }

    class ConsolePrint : IPrintDriver
    {

        public void PrintRoad(Road road, Object o)
        {
            CharMatrix cm = (CharMatrix)o;
            int x, y;
            int CCx = Conversions.WCpointToCCpoint(road.GetXLocation());
            int CCy = Conversions.WCpointToCCpoint(-road.GetYLocation());
            int distance = 0;
            int CCRoadLength = Conversions.WClengthToCClength(road.GetLength());
            if (road.GetHeading() == Heading.North || road.GetHeading() == Heading.South)
            {
                    x = (int)CCx;
                    if (x >= 0 && x < Constants.CharMapSize)
                    {
                        while (distance < CCRoadLength)
                        {
                            y = (int)(CCy - distance);
                            if (y >= 0 && y < Constants.CharMapSize)
                            {
                                for (int i = 0; i < 5; i += 2)
                                {
                                    if (cm.map[y][x + i] == ' ')
                                    {
                                        cm.map[y][x + i] = '|';
                                    }
                                }
                            }
                            distance += 1;
                        }
                    }
            }
            else if (road.GetHeading() == Heading.East || road.GetHeading() == Heading.West)
            {
                y = (int)CCy;
                if (y >= 0 && y < Constants.CharMapSize)
                {
                    while (distance < CCRoadLength)
                    {
                        x = (int)(CCx + distance);
                        if (x >= 0 && x < Constants.CharMapSize)
                        {
                            for (int i = 0; i < 5; i += 2)
                            {
                                if (cm.map[y + i][x] == ' ')
                                {
                                    cm.map[y + i][x] = '-';
                                }
                            }
                        }
                        distance += 1;
                    }
                }
            }
        }

        public void PrintCar(Car car, Object o)
        {

        }

        public void PrintRoadItem(RoadItem roadItem, Object o, GUI gui)
        {
            CharMatrix cm = (CharMatrix)o;
            Road thisRoad = roadItem.GetCurrentRoad();

            int x = (int)Conversions.WCpointToCCpoint(thisRoad.GetXLocation());
            int y = (int)Conversions.WCpointToCCpoint(-thisRoad.GetYLocation());

            double mileMarker = roadItem.GetMileMarker();
            int mileMarkerDist = (int)Conversions.WClengthToCClength(mileMarker);

			int otherX, otherY;
            if (thisRoad.GetHeading() == Heading.North)
            {
                x -= 1;
                y = (int)(y - mileMarkerDist);
                otherY = y;
                otherX = x + 6;
            }
            else if (thisRoad.GetHeading() == Heading.East)
            {
                y -= 1;
                x = (int)(x + mileMarkerDist);
                otherX = x;
                otherY = y + 6;
            }

            else return;

            char[] chars = gui.GetInterfaceUnitRoadItem(roadItem).GetChar();
            if (x - chars.Length >= 0 && x < Constants.CharMapSize && y >= 0 && y < Constants.CharMapSize)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (thisRoad.GetHeading() == Heading.North || thisRoad.GetHeading() == Heading.South)
                    {
                        cm.map[y][x - (chars.Length - i - 1)] = chars[i];
                        cm.map[otherY][otherX + i] = chars[i];
                    }
                    else
                    {
                        cm.map[y][x + i] = chars[i];
                        cm.map[otherY][otherX + i] = chars[i];
                    }
                }
            }
        }
    }

    class DebugPrint : IPrintDriver
    {
        public void PrintRoad(Road road, Object o)
        {
            Console.WriteLine("Road: " + road.GetRoadName() + "\t" + road.GetXLocation() + "\t" + road.GetYLocation() +
                              "\t" + road.GetLength() + "\t" + road.GetHeading());
        }

        public void PrintCar(Car car, Object o)
        {
            // Console.WriteLine("Car: " + car.GetCarName() + " " + car.GetXLocation() + " " + car.GetYLocation() + " " + car.GetHeading());
        }

        public void PrintStopSign(StopSign stopSign, Object o)
        {

        }

        public void PrintSpeedLimit(SpeedLimit speedLimit, Object o)
        {

        }

        public void PrintRoadItem(RoadItem roadItem, Object o, GUI gui)
        {

        }
    }
}
