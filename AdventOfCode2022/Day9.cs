namespace AdventOfCode2022;

public class Day9
{
    public Day9()
    {
    }

    public static int PartOne()
    {
        var commands = Utilities.GetInputLines(9);
        var visited = new HashSet<(int x, int y)>();
        var head = (x: 0, y: 0);
        var tail = (x: 0, y: 0);

        foreach (var command in commands)
        {
            var direction = command.Split(' ')[0];
            var amount = int.Parse(command.Split(' ')[1]);

            for (int i = 0; i < amount; i++)
            {
                switch (direction) {
                    case "U":
                        head.y++;
                        break;
                    case "D":
                        head.y--;
                        break;
                    case "R":
                        head.x++;
                        break;
                    case "L":
                        head.x--;
                        break;
                    default:
                        Console.WriteLine($"Invalid direction {direction}");
                        break;
                }

                tail = MoveTail(head, tail, visited, true);
            }
        }

        return visited.Count;
    }

    public static int PartTwo()
    {
        var commands = Utilities.GetInputLines(9);
        var visited = new HashSet<(int x, int y)>();
        var knots = new List<(int x, int y)>();

        for (int i = 0; i < 10; i++)
            knots.Add((0, 0));

        foreach (var command in commands)
        {
            var direction = command.Split(' ')[0];
            var amount = int.Parse(command.Split(' ')[1]);

            for (int i = 0; i < amount; i++)
            {
                switch (direction)
                {
                    case "U":
                        knots[0] = (knots[0].x, knots[0].y + 1);
                        break;
                    case "D":
                        knots[0] = (knots[0].x, knots[0].y - 1);
                        break;
                    case "R":
                        knots[0] = (knots[0].x + 1, knots[0].y);
                        break;
                    case "L":
                        knots[0] = (knots[0].x - 1, knots[0].y);
                        break;
                    default:
                        Console.WriteLine($"Invalid direction {direction}");
                        break;
                }

                for (int j = 1; j < 10; j++)
                    knots[j] = MoveTail(knots[j - 1], knots[j], visited, j == 9);
            }
        }

        return visited.Count;
    }

    private static (int x, int y) MoveTail((int x, int y) head, (int x, int y) tail, ISet<(int x, int y)> visited, bool isTail)
    {
        if (head.x - tail.x == 2 && head.y == tail.y)
        {
            tail.x++;
        }
        else if (tail.x - head.x == 2 && head.y == tail.y)
        {
            tail.x--;
        }
        else if (head.y - tail.y == 2 && head.x == tail.x)
        {
            tail.y++;
        }
        else if (tail.y - head.y == 2 && head.x == tail.x)
        {
            tail.y--;
        }
        else if ((head.x - tail.x == 2 && head.y - tail.y >= 1) || (head.x - tail.x >= 1 && head.y - tail.y == 2))
        {
            tail.x++;
            tail.y++;
        }
        else if ((tail.x - head.x == 2 && head.y - tail.y >= 1) || (tail.x - head.x >= 1 && head.y - tail.y == 2))
        {
            tail.x--;
            tail.y++;
        }
        else if ((tail.y - head.y == 2 && head.x - tail.x >= 1) || (tail.y - head.y >= 1 && head.x - tail.x == 2))
        {
            tail.x++;
            tail.y--;
        }
        else if ((tail.y - head.y == 2 && tail.x - head.x >= 1) || (tail.y - head.y >= 1 && tail.x - head.x == 2))
        {
            tail.x--;
            tail.y--;
        }

        if (isTail)
            visited.Add((tail.x, tail.y));

        return (tail.x, tail.y);
    }
}
