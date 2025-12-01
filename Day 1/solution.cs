using System;

class Program
{
    static void Main(string[] args)
    {
        int lowerBarrier = 0;
        int upperBarrier = 100;
        int start = 50;
        int range = upperBarrier - lowerBarrier;

        Console.WriteLine($"Range: {range}");

        // read nmbers from txt file
        var filename = "numbers.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);
        int currentPosition = start;
        int countZeros = 0;
        foreach (string line in lines)
        {
            bool positiveSign = line.StartsWith("R");
            int step = (positiveSign ? 1 : -1) * int.Parse(line.Substring(1));
            Console.WriteLine($"Step: {step}");

            int addedStep = currentPosition + step;
            Console.WriteLine($"AddedStep: {addedStep}");

            int moduloStep = ((addedStep % range) + range) % range;
            Console.WriteLine($"ModuloStep: {moduloStep}");

            currentPosition = moduloStep;
            Console.WriteLine($"CurrentPosition: {currentPosition}");

            if (currentPosition == 0)
            {
                countZeros++;
            }
        }
        Console.WriteLine($"Final Position: {currentPosition}");
        Console.WriteLine($"Count of Zeros: {countZeros}");
    }
}