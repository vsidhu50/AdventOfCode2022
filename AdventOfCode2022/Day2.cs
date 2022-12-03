namespace AdventOfCode2022;

public class Day2
{
    public Day2()
    {
    }

    public static int PartOne()
    {
        var rounds = Utilities.GetInputLines(2);
        var score = 0;

        foreach (var round in rounds)
        {
            var you = round[2] - 'X';
            var them = round[0] - 'A';

            score += you + 1;

            if (you == them)
                score += 3;
            else if ((them + 1) % 3 == you)
                score += 6;
        }

        return score;
    }

    public static int PartTwo()
    {
        var rounds = Utilities.GetInputLines(2);
        var score = 0;

        foreach (var round in rounds)
        {
            var result = round[2] - 'X';
            var them = round[0] - 'A';

            score += 1 + result switch
            {
                0 => (them + 3 - 1) % 3,
                1 => them + 3,
                2 => (them + 1) % 3 + 6,
                _ => 0
            };
        }

        return score;
    }
}
