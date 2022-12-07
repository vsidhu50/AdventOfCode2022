namespace AdventOfCode2022;

public class Day6
{
    public Day6()
    {
    }

    public static int PartOne()
    {
        var buffer = Utilities.GetInputLines(6)[0];

        for (int i = 3; i < buffer.Length; i++)
        {
            var lastFour = new HashSet<char>();

            for (int j = i - 3; j <= i; j++)
                lastFour.Add(buffer[j]);

            if (lastFour.Count == 4)
                return i + 1;
        }

        return -1;
    }

    public static int PartTwo()
    {
        var buffer = Utilities.GetInputLines(6)[0];

        for (int i = 13; i < buffer.Length; i++)
        {
            var lastFour = new HashSet<char>();

            for (int j = i - 13; j <= i; j++)
                lastFour.Add(buffer[j]);

            if (lastFour.Count == 14)
                return i + 1;
        }

        return -1;
    }
}
