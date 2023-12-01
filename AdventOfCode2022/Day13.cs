namespace AdventOfCode2022;

public class Day13
{
    public Day13()
    {
    }

    public static int PartOne()
    {
        var pairs = Utilities.GetInputParagraphs(13);
        var index = 1;
        var sum = 0;

        foreach (var pair in pairs)
        {
            var lines = Utilities.GetLines(pair);
            var left = lines[0];
            var right = lines[1];

            index++;
        }

        return sum;
    }

    public static int PartTwo()
    {
        return -1;
    }
}
