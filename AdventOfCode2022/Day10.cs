namespace AdventOfCode2022;

public class Day10
{
    public Day10()
    {
    }

    public static int PartOne()
    {
        var commands = Utilities.GetInputLines(10);
        var sum = 0;
        var cycle = 1;
        var x = 1;

        foreach (var command in commands)
        {
            if (cycle % 40 == 20)
                sum += cycle * x;

            var instruction = command.Split(' ')[0];

            if (instruction == "noop")
                cycle++;
            else
            {
                var amount = int.Parse(command.Split(' ')[1]);

                cycle++;
                if (cycle % 40 == 20)
                    sum += cycle * x;

                cycle++;
                x += amount;
            }
        }
        return sum;
    }

    public static int PartTwo()
    {
        var commands = Utilities.GetInputLines(10);
        var cycle = 0;
        var x = 1;
        var crt = "";

        foreach (var command in commands)
        {
            if (cycle % 40 == 0)
                crt += "\n";

            if (cycle % 40 >= x - 1 && cycle % 40 <= x + 1)
                crt += "#";
            else
                crt += ".";

            var instruction = command.Split(' ')[0];

            if (instruction == "noop")
                cycle++;
            else
            {
                var amount = int.Parse(command.Split(' ')[1]);

                cycle++;

                if (cycle % 40 == 0)
                    crt += "\n";

                if (cycle % 40 >= x - 1 && cycle % 40 <= x + 1)
                    crt += "#";
                else
                    crt += ".";

                cycle++;
                x += amount;
            }
        }

        Console.WriteLine(crt);
        return -1;
    }
}
