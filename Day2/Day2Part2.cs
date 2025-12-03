namespace AdventOfCode2025.Day2;

public class Day2Part2
{
    readonly string _inputPath = "Day2/input.txt";
    private List<string> _invalidIds = [];
    
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
                    
                    if (IsInvalidId(i))
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
    
    // String pattern repetition check, much better than the previous half-and-half method for part 1 tbh
    bool IsInvalidId(long id)
    {
        string stringId = id.ToString();
        int length = stringId.Length;

        // Check every possible pattern length
        for (int patLen = 1; patLen <= length / 2; patLen++)
        {
            if (length % patLen != 0)
            {
                continue;
            }

            string pattern = stringId.Substring(0, patLen);

            bool allMatch = true;
            for (int i = patLen; i < length; i += patLen)
            {
                if (stringId.Substring(i, patLen) != pattern)
                {
                    allMatch = false;
                    break;
                }
            }

            if (allMatch)
            {
                return true;
            }
        }

        return false;
    }
}