namespace AdventOfCode2025.Day3;

public class Day3Part2
{
    string _inputPath = "Day3/test_input.txt";

    public void Run()
    {
        List<string> banks = File.ReadLines(_inputPath).ToList();

        int numBatteries = 12;
        
        int firstPosition = 0;
        int secondPosition = 0;
        int thirdPosition = 0;
        int fourthPosition = 0;
        int fifthPosition = 0;
        int sixthPosition = 0;
        int seventhPosition = 0;
        int eighthPosition = 0;
        int ninthPosition = 0;
        int tenthPosition = 0;
        int eleventhPosition = 0;
        
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
                    secondPosition = j;
                }
            }
            
            char thirdLargest = char.MinValue;
            for (int k = secondPosition + 1; k < bank.Length; k++)
            {
                if(bank[k] > thirdLargest && bank[k] != secondLargest)
                {
                    thirdLargest = bank[k];
                    thirdPosition = k;
                }
            }
            
            char fourthLargest = char.MinValue;
            for (int l = thirdPosition + 1; l < bank.Length; l++)
            {
                if(bank[l] > fourthLargest && bank[l] != secondLargest && bank[l] != thirdLargest)
                {
                    fourthLargest = bank[l];
                    fourthPosition = l;
                }
            }
            
            char fifthLargest = char.MinValue;
            for (int m = fourthPosition + 1; m < bank.Length; m++)
            {
                if(bank[m] > fifthLargest && bank[m] != secondLargest && bank[m] != thirdLargest && bank[m] != fourthLargest)
                {
                    fifthLargest = bank[m];
                    fifthPosition = m;
                }
            }
            
            char sixthLargest = char.MinValue;
            for (int n = fifthPosition + 1; n < bank.Length; n++)
            {
                if(bank[n] > sixthLargest && bank[n] != secondLargest && bank[n] != thirdLargest && bank[n] != fourthLargest && bank[n] != fifthLargest)
                {
                    sixthLargest = bank[n];
                    sixthPosition = n;
                }
            }
            
            char seventhLargest = char.MinValue;
            for (int o = sixthPosition + 1; o < bank.Length; o++)
            {
                if(bank[o] > seventhLargest && bank[o] != secondLargest && bank[o] != thirdLargest && bank[o] != fourthLargest && bank[o] != fifthLargest && bank[o] != sixthLargest)
                {
                    seventhLargest = bank[o];
                    seventhPosition = o;
                }
            }
            
            char eighthLargest = char.MinValue;
            for (int p = seventhPosition + 1; p < bank.Length; p++)
            {
                if(bank[p] > eighthLargest && bank[p] != secondLargest && bank[p] != thirdLargest && bank[p] != fourthLargest && bank[p] != fifthLargest && bank[p] != sixthLargest && bank[p] != seventhLargest)
                {
                    eighthLargest = bank[p];
                    eighthPosition = p;
                }
            }
            
            char ninthLargest = char.MinValue;
            for (int q = eighthPosition + 1; q < bank.Length; q++)
            {
                if(bank[q] > ninthLargest && bank[q] != secondLargest && bank[q] != thirdLargest && bank[q] != fourthLargest && bank[q] != fifthLargest && bank[q] != sixthLargest && bank[q] != seventhLargest && bank[q] != eighthLargest)
                {
                    ninthLargest = bank[q];
                    ninthPosition = q;
                }
            }
            
            char tenthLargest = char.MinValue;
            for (int r = ninthPosition + 1; r < bank.Length; r++)
            {
                if(bank[r] > tenthLargest && bank[r] != secondLargest && bank[r] != thirdLargest && bank[r] != fourthLargest && bank[r] != fifthLargest && bank[r] != sixthLargest && bank[r] != seventhLargest && bank[r] != eighthLargest && bank[r] != ninthLargest)
                {
                    tenthLargest = bank[r];
                    tenthPosition = r;
                }
            }
            
            char eleventhLargest = char.MinValue;
            for (int s = tenthPosition + 1; s < bank.Length; s++)
            {
                if(bank[s] > eleventhLargest && bank[s] != secondLargest && bank[s] != thirdLargest && bank[s] != fourthLargest && bank[s] != fifthLargest && bank[s] != sixthLargest && bank[s] != seventhLargest && bank[s] != eighthLargest && bank[s] != ninthLargest && bank[s] != tenthLargest)
                {
                    eleventhLargest = bank[s];
                    eleventhPosition = s;
                }
            }
            
            char twelfthLargest = char.MinValue;
            for (int t = eleventhPosition + 1; t < bank.Length; t++)
            {
                if(bank[t] > twelfthLargest && bank[t] != secondLargest && bank[t] != thirdLargest && bank[t] != fourthLargest && bank[t] != fifthLargest && bank[t] != sixthLargest && bank[t] != seventhLargest && bank[t] != eighthLargest && bank[t] != ninthLargest && bank[t] != tenthLargest && bank[t] != eleventhLargest)
                {
                    twelfthLargest = bank[t];
                }
            }
            
            sum += int.Parse($"{firstLargest}{secondLargest}{thirdLargest}{fourthLargest}{fifthLargest}{sixthLargest}{seventhLargest}{eighthLargest}{ninthLargest}{tenthLargest}{eleventhLargest}{twelfthLargest}");
        }
        
        Console.WriteLine($"Answer to day3 part2: {sum}");
    }
}