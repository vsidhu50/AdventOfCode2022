namespace AdventOfCode2022;

public class Day3
{
    public Day3()
    {
    }

    public static int PartOne()
    {
        var sacks = Utilities.GetInputLines(3);
        var sum = 0;

        foreach (var sack in sacks)
        {
            var compLength = sack.Length / 2;
            var comp1 = sack[..compLength];
            var comp2 = sack[compLength..];

            var common = comp1.Intersect(comp2).First();

            if (common < 'a')
                sum += common - 'A' + 27;
            else
                sum += common - 'a' + 1;
        }

        return sum;
    }

    public static int PartTwo()
    {
        var sacks = Utilities.GetInputLines(3);
        var sum = 0;

        for (var i = 0; i < sacks.Count; i += 3)
        {
            var sack1 = sacks[i];
            var sack2 = sacks[i + 1];
            var sack3 = sacks[i + 2];

            var commonLetters = sack1.Intersect(sack2);
            var common = commonLetters.Intersect(sack3).First();

            if (common < 'a')
                sum += common - 'A' + 27;
            else
                sum += common - 'a' + 1;
        }

        return sum;
    }
}
