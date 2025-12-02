namespace AdventOfCode2025.Day1;

public readonly struct Rotation(int steps, string direction)
{
    public string Direction { get; } = direction;
    public int Steps { get; } = steps;
}