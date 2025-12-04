namespace AdventOfCode2025.Day3;

public class Day3Part1
{
    string _inputPath = "Day3/input.txt";

    public void Run()
    {
        List<string> banks = File.ReadLines(_inputPath).ToList();

        int numBatteries = 2;
        int firstPosition = 0;
        int sum = 0;
        foreach (string bank in banks)
        {
            char firstLargest = char.MinValue;
            for (int i = 0; i < bank.Length - numBatteries + 1; i++)
            {
                if (bank[i] > firstLargest)
                {
                    firstLargest = bank[i];
                    firstPosition = i;
                }
            }

            char secondLargest = char.MinValue;
            for (int j = firstPosition + 1; j < bank.Length; j++)
            {
                if(bank[j] > secondLargest)
                {
                    secondLargest = bank[j];
                }
            }
            
            sum += int.Parse($"{firstLargest}{secondLargest}");
        }
        
        Console.WriteLine($"Answer to day3 part1: {sum}");
    }
}