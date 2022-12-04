namespace AdventOfCode2022;

public class Day4
{
    public Day4()
    {
    }

    public static int PartOne()
    {
        var lines = Utilities.GetInputLines(4);
        var count = 0;

        foreach (var line in lines)
        {
            var first = line.Split(',')[0];
            var second = line.Split(',')[1];

            var limitsOne = (int.Parse(first.Split('-')[0]), int.Parse(first.Split('-')[1]));
            var limitsTwo = (int.Parse(second.Split('-')[0]), int.Parse(second.Split('-')[1]));

            var rangeOne = Enumerable.Range(limitsOne.Item1, limitsOne.Item2 - limitsOne.Item1 + 1);
            var rangeTwo = Enumerable.Range(limitsTwo.Item1, limitsTwo.Item2 - limitsTwo.Item1 + 1);

            if (rangeOne.All(rangeTwo.Contains) || rangeTwo.All(rangeOne.Contains))
                count++;
        }

        return count;
    }

    public static int PartTwo()
    {
        var lines = Utilities.GetInputLines(4);
        var count = 0;

        foreach (var line in lines)
        {
            var first = line.Split(',')[0];
            var second = line.Split(',')[1];

            var limitsOne = (int.Parse(first.Split('-')[0]), int.Parse(first.Split('-')[1]));
            var limitsTwo = (int.Parse(second.Split('-')[0]), int.Parse(second.Split('-')[1]));

            var rangeOne = Enumerable.Range(limitsOne.Item1, limitsOne.Item2 - limitsOne.Item1 + 1);
            var rangeTwo = Enumerable.Range(limitsTwo.Item1, limitsTwo.Item2 - limitsTwo.Item1 + 1);

            if (rangeOne.Intersect(rangeTwo).Any())
                count++;
        }

        return count;
    }
}
