namespace RockScienceTask;
public struct WaterPressurePoints
{
    public double X { get; }
    public double Y { get; }
    public double WaterPressure { get; }

    public WaterPressurePoints(double x, double y, double waterPressure)
    {
        X = x;
        Y = y;
        WaterPressure = waterPressure;
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {WaterPressure:F3})";
    }
}
