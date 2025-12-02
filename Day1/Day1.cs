using System.Text.RegularExpressions;

namespace AdventOfCode2025.Day1;

public class Day1
{
    private int[] _dialPositions = new int[100];
    private int _pointer = 50;
    private string _inputPath = "Day1/input.txt";
    private List<Rotation> _rotations = [];
    private int _numberOfTimesAtZero;   
    
    /// <summary>
    /// Completes the Day 1 challenge.
    /// </summary>
    public void Run()
    {
        AllocateDialPositions();
        AllocateRotations(_inputPath);
        
        PerformRotations();
        Console.WriteLine($"Dial has pointed to zero {_numberOfTimesAtZero} times.");
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
            int dialPosition = MovePointer(rotation.Steps, rotation.Direction);
            PrintDialRotation(rotation, dialPosition);
            if (dialPosition == 0)
            {
                _numberOfTimesAtZero++;
            }
        }
    }

    /// <summary>
    /// Moves the pointer on the dialPositions array based on the direction and number of movements.
    /// </summary>
    /// <param name="movements">number of rotations</param>
    /// <param name="direction">direction of rotation</param>
    /// <returns></returns>
    private int MovePointer(int movements, string direction)
    {
        if (direction == "R")
        {
            _pointer += movements;
            while (_pointer >= 100)
            {
                _pointer = _pointer - 100;
            }
        }

        if (direction == "L")
        {
            _pointer -= movements;
            while (_pointer < 0)
            {
                _pointer = 100 + _pointer;
            }
        }
        return _dialPositions[_pointer];
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
}