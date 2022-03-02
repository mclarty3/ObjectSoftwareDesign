static class Conversions
{
    public static int WCPointToCCPoint(double val)
    {
        return (int)(val * (Constants.CharMapSize / Constants.WorldSize) + (Constants.CharMapSize / 2));
    }

    public static int WCPointToGCPoint(double val)
    {
        return (int)(val * (Constants.PixelMapSize / Constants.WorldSize) + (Constants.PixelMapSize / 2));
    }
}