using System.Text.RegularExpressions;

namespace AdventOfCode2025.Day1;

public class Part2
{
     private int[] _dialPositions = new int[100];
    private int _pointer = 50;
    private string _inputPath = "Day1/input.txt";
    private List<Rotation> _rotations = [];
    private int _numberOfTimesAtZero;   
    private bool ispartOne = false;
    
    
    /// <summary>
    /// Completes the Day 1 part2 challenge.
    /// </summary>
    public void Run()
    {
        AllocateDialPositions();
        AllocateRotations(_inputPath);
        
        PerformRotations();
        Console.WriteLine($"Answer to day1 part2: {_numberOfTimesAtZero}");
    }

    /// <summary>
    /// Allocates the dial positions array from 0 to 99.
    /// </summary>
    private void AllocateDialPositions()
    {
        for (int i = 0; i < 100; i++)
        {
            _dialPositions[i] = i;
        }
    }

    /// <summary>
    /// Performs the rotations as per the rotations list.
    /// Tracks how many times the dial points to zero.
    /// </summary>
    private void PerformRotations()
    {
        foreach (var rotation in _rotations)
        {
            for (int i = 0; i < rotation.Steps; i++)
            {
                Click(rotation.Direction);
                if(_pointer == 0)
                {
                    _numberOfTimesAtZero++;
                }
            }
        }
    }
    
    /// <summary>
    /// Allocates the rotations list from the input file.
    /// </summary>
    /// <param name="inputPath">rotation file input path</param>
    private void AllocateRotations(string inputPath)
    {
        List<string> lines = File.ReadLines(inputPath).ToList();
        foreach (string line in lines)
        {
            // Split after R or L character
            string[] splits = Regex.Split(line, @"(?<=[RL])"); 
            
            string direction = splits[0];
            int steps = int.Parse(splits[1]);
            Rotation rotation = new Rotation(steps, direction);
            
            _rotations.Add(rotation);
        }
    }

    /// <summary>
    /// Helper method to print the rotation details.
    /// </summary>
    /// <param name="rotation">Rotation object</param>
    /// <param name="dialPosition">current dial position</param>
    private void PrintDialRotation(Rotation rotation, int dialPosition)
    {
        Console.WriteLine($"Dial rotated {rotation.Direction}{rotation.Steps} to point at {dialPosition}");
    }
    
    /// <summary>
    /// Move the dial pointer one step in the given direction.
    /// </summary>
    /// <param name="direction">Direction of rotation</param>
    private void Click(string direction)
    {
        if(direction == "R")
        {
            if (_pointer == 99)
            {
                _pointer = 0;
            }
            else
            {
                _pointer++;
            }
        }
        else if(direction == "L")
        {
            if (_pointer == 0)
            {
                _pointer = 99;
            }
            else
            {
                _pointer--;
            }
        }
    }
}