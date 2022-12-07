namespace AdventOfCode2022;

public class Day5
{
    public Day5()
    {
    }

    public static string PartOne()
    {
        var commands = Utilities.GetLines(Utilities.GetInputParagraphs(5)[1]);
        var stacks = new string[] { "NCRTMZP", "DNTSBZ", "MHQRFCTG", "GRZ", "ZNRH", "FHSWPZLD", "WDZRCGH", "SJFLHWZQ", "ZQPWN" }.Select(x => new Stack<char>(x.ToCharArray())).ToList();
        var tops = "";

        foreach (var command in commands)
        {
            var nums = command.Replace("move ", "").Replace("from ", "").Replace("to ", "").Split(" ");
            var quant = int.Parse(nums[0]);
            var from = int.Parse(nums[1]) - 1;
            var to = int.Parse(nums[2]) - 1;

            for (int i = 0; i < quant; i++)
            {
                var moved = stacks[from].Pop();
                stacks[to].Push(moved);
            }
        }

        foreach (var stack in stacks)
            tops += stack.Peek();

        return tops;
    }

    public static string PartTwo()
    {
        var commands = Utilities.GetLines(Utilities.GetInputParagraphs(5)[1]);
        var stacks = new string[] { "NCRTMZP", "DNTSBZ", "MHQRFCTG", "GRZ", "ZNRH", "FHSWPZLD", "WDZRCGH", "SJFLHWZQ", "ZQPWN" }.Select(x => new Stack<char>(x.ToCharArray())).ToList();
        var tops = "";

        foreach (var command in commands)
        {
            var nums = command.Replace("move ", "").Replace("from ", "").Replace("to ", "").Split(" ");
            var quant = int.Parse(nums[0]);
            var from = int.Parse(nums[1]) - 1;
            var to = int.Parse(nums[2]) - 1;

            var moved = new Stack<char>();

            for (int i = 0; i < quant; i++)
                moved.Push(stacks[from].Pop());

            var numMoved = moved.Count;

            for (int i = 0; i < numMoved; i++)
                stacks[to].Push(moved.Pop());
        }

        foreach (var stack in stacks)
            tops += stack.Peek();

        return tops;
    }
}
