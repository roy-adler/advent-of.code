using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Print different colors in the same console line for different parts
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("red ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("blue");
        Console.ForegroundColor = originalColor;
        Print("Test r[red text] normal b[tex]t white text g[green text] y[yellow text] end.");

        return;

        int lowerBarrier = 0;
        int upperBarrier = 100;
        int start = 50;
        int range = upperBarrier - lowerBarrier;

        Console.WriteLine($"Range: {range}\n");

        // read nmbers from txt file
        var filename = "test2.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);
        int currentPosition = start;
        int countEndingZeros = 0;
        int countPassingZeros = 0;

        foreach (string line in lines)
        {
            Console.WriteLine($"StartPosition: {currentPosition}");

            Console.WriteLine($"Step Description: {line}");

            bool positiveSign = line.StartsWith("R");
            int step = (positiveSign ? 1 : -1) * int.Parse(line.Substring(1));
            Console.WriteLine($"Step: {step}");

            int addedStep = currentPosition + step;
            // Create a ||number|| function to handle negative  numbers
            var absStep = Math.Abs(step);
            Console.WriteLine($"AddedStep: {currentPosition} {(positiveSign ? "+" : "-")} {absStep} = {addedStep}");

            var numberOfRanges = (int)Math.Floor((double)addedStep / range);
            Console.WriteLine($"NumberOfRanges: {addedStep}/{range} = {(double)addedStep / range}");
            Console.WriteLine($"Floored: ⌊{addedStep}/{range}⌋ = {numberOfRanges}");

            // modulo with rest
            var modulo = absStep % range;
            Console.WriteLine($"Modulo: {absStep} % {range} = {modulo}");

            countPassingZeros += Math.Abs(numberOfRanges);
            int adjustedStep = addedStep - (numberOfRanges * range);
            Console.WriteLine($"AdjustedStep: {addedStep} - ({numberOfRanges} * {range}) = {adjustedStep}");

            int moduloStep = ((addedStep % range) + range) % range;
            Console.WriteLine($"ModuloStep: (({addedStep} % {range}) + {range}) % {range} = {moduloStep}");

            currentPosition = adjustedStep;
            Console.WriteLine($"EndPosition: {currentPosition}");

            if (currentPosition == 0)
            {
                countEndingZeros++;
            }
            Console.WriteLine("Count of Zeros so far: " + countEndingZeros);
            Console.WriteLine("Count of Passing Zeros so far: " + countPassingZeros);
            // Always adds a newline, even if the input string already ends with one.
                    Console.WriteLine();
        }
        Console.WriteLine($"Final Position: {currentPosition}");
        Console.WriteLine($"Count of Zeros: {countEndingZeros}");
        Console.WriteLine($"Count of Passing Zeros: {countPassingZeros}");
        Console.WriteLine($"Sum of Counts: {countEndingZeros + countPassingZeros}");
    }

    static void Print(string s)
    {
        var colors = new Dictionary<char, ConsoleColor>
        {
            { 'r', ConsoleColor.Red },
            { 'b', ConsoleColor.Blue },
            { 'g', ConsoleColor.Green },
            { 'y', ConsoleColor.Yellow }
        };
        var defaultColor = ConsoleColor.White;
        int i = 0;
        
        while (i < s.Length)
        {
            if (i < s.Length - 1 && colors.ContainsKey(s[i]) && s[i + 1] == '[')
            {
                char colorKey = s[i];
                i += 2;
                int endIndex = s.IndexOf("]", i);
                if (endIndex != -1)
                {
                    Console.ForegroundColor = colors[colorKey];
                    Console.Write(s.Substring(i, endIndex - i));
                    Console.ForegroundColor = defaultColor;
                    i = endIndex + 1;
                }
            }
            else
            {
                Console.Write(s[i]);
                i++;
            }
        }
        
        Console.WriteLine();
    }
}