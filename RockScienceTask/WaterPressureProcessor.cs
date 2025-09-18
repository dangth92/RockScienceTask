namespace RockScienceTask;
public class WaterPressureProcessor
{
    private const double TOLERANCE = 1e-3;

    public static void WriteWaterPressure(List<WaterPressurePoints> points, string filePath = "water_pressure_points.txt")
    {
        if (points == null || points.Count == 0)
        {
            Console.WriteLine("No points to process.");
            return;
        }

        // Filter out duplicates based on coordinates with tolerance
        var uniquePoints = new List<WaterPressurePoints>();

        foreach (var point in points)
        {
            bool isDuplicate = false;

            foreach (var existingPoint in uniquePoints)
            {
                // Check if points are close to each other within tolerance
                if (Math.Abs(point.X - existingPoint.X) < TOLERANCE &&
                    Math.Abs(point.Y - existingPoint.Y) < TOLERANCE)
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                uniquePoints.Add(point);
            }
        }

        // Write to file
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Water Pressure Points:");
                writer.WriteLine("X\tY\tWater Pressure");
                writer.WriteLine(new string('-', 40));

                foreach (var point in uniquePoints)
                {
                    writer.WriteLine($"{point.X}\t{point.Y}\t{point.WaterPressure}");
                }
            }

            Console.WriteLine($"Successfully wrote {uniquePoints.Count} unique points to {filePath}");
            Console.WriteLine($"Removed {points.Count - uniquePoints.Count} duplicate points");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }
}
