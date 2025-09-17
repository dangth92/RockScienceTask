namespace RockScienceTask
{
    // Task 1: Water Pressure Points Processing
    // Example usage and testing
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test data based on the example
            var testPoints = new List<WaterPressurePoints>
            {
                new WaterPressurePoints(0, 0, 0),       // Keep - first occurrence
                new WaterPressurePoints(0, 0, 15),      // Remove - duplicate coordinates
                new WaterPressurePoints(1e-19, 0, 0),   // Remove - within tolerance of (0,0)
                new WaterPressurePoints(1, 0, 5),       // Keep - unique coordinates
                new WaterPressurePoints(0, 1, 10),      // Keep - unique coordinates
                new WaterPressurePoints(1, 1, 20),      // Keep - unique coordinates
                new WaterPressurePoints(0.0005, 0, 25), // Remove - within tolerance of (0,0)
                new WaterPressurePoints(2, 2, 30)       // Keep - unique coordinates
            };

            Console.WriteLine("Original points:");
            for (int i = 0; i < testPoints.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {testPoints[i]}");
            }

            Console.WriteLine("\nProcessing points...\n");

            WaterPressureProcessor.WriteWaterPressure(testPoints);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
