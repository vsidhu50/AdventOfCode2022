namespace AdventOfCode2022;
public class Day1
{
    public Day1()
    {
    }

    public static int PartOne()
    {
        var elves = Utilities.GetInputParagraphs(1);
        var sums = new List<int>();

        foreach (var elf in elves)
            sums.Add(Utilities.GetNums(elf).Sum());

        return sums.Max();
    }

    public static int PartTwo()
    {
        var elves = Utilities.GetInputParagraphs(1);
        var sums = new List<int>();

        foreach (var elf in elves)
            sums.Add(Utilities.GetNums(elf).Sum());

        var sum = 0;

        for (var i = 0; i < 3; i++)
        {
            var max = sums.Max();
            sum += max;
            sums.Remove(max);
        }

        return sum;
    }
}
