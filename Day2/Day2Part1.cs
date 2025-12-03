namespace AdventOfCode2025.Day2;

public class Day2Part1
{
    string _inputPath = "Day2/input.txt";
    private List<string> _invalidIds = new List<string>();
    public void Run()
    {
        List<string> input = File.ReadLines(_inputPath).ToList();
        foreach (string line in input)
        {
            List<string> idGroups = line.Split(",").ToList();

            foreach (string idGroup in idGroups)
            {
                string[] ids = idGroup.Split("-");
                Int64 startId = Int64.Parse(ids[0]);
                Int64 endId = Int64.Parse(ids[1]);

                for (Int64 i = startId; i <= endId; i++)
                {
                    string idString = i.ToString();
                    int length = idString.Length;
                    if(length % 2 != 0)
                    {
                        //skip odd length ids
                        continue;
                    }
                    //split string in half and compare
                    string firstHalf = idString.Substring(0, length / 2);
                    string secondHalf = idString.Substring(length / 2, length / 2);

                    if (firstHalf == secondHalf)
                    {
                        _invalidIds.Add(idString);
                    }
                }
            }
        }

        Int64 total = 0;
        foreach (string invalidId in _invalidIds)
        {
            total += Int64.Parse(invalidId);
        }
        Console.WriteLine($"Answer to day2 part2: {total}");

    }
}