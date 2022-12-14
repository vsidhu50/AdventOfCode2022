using System;

namespace AdventOfCode2022;

public class Day12
{
    public Day12()
    {
    }

    public static int PartOne()
    {
        var grid = Utilities.GetInputGridChars(12);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);

        grid[20, 0] = 'a';
        grid[20, 58] = 'z';

        var start = (20, 0);
        var end = (20, 58);

        var parents = new Dictionary<(int row, int col), (int row, int col)>();
        var queue = new Queue<(int row, int col)>();

        queue.Enqueue(start);
        parents[start] = (-1, -1);

        while (queue.Any())
        {
            var curr = queue.Dequeue();

            if (curr == end)
                break;

            foreach (var neighbor in Neighbors(curr, grid, numRows, numCols))
            {
                if (!parents.ContainsKey(neighbor))
                {
                    parents.Add(neighbor, curr);
                    queue.Enqueue(neighbor);
                }
            }
        }

        var curr1 = end;
        var path = new List<(int row, int col)>();

        while (curr1 != (-1, -1))
        {
            path.Insert(0, curr1);
            curr1 = parents[curr1];
        }

        return path.Count - 1;
    }

    public static int PartTwo()
    {
        var grid = Utilities.GetInputGridChars(12);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);

        grid[20, 0] = 'a';
        grid[20, 58] = 'z';

        var starts = new List<(int row, int col)>();

        for (int i = 0; i < numRows; i++)
            for (int j = 0; j < numCols; j++)
                if (grid[i, j] == 'a')
                    starts.Add((i, j));

        var lengths = new List<int>();
        foreach (var start in starts)
            lengths.Add(PathLength(start, grid, numRows, numCols));

        return lengths.Min();
    }

    private static int PathLength((int row, int col) start, char[,] grid, int numRows, int numCols)
    {
        var end = (20, 58);
        var parents = new Dictionary<(int row, int col), (int row, int col)>();
        var queue = new Queue<(int row, int col)>();

        queue.Enqueue(start);
        parents[start] = (-1, -1);

        while (queue.Any())
        {
            var curr = queue.Dequeue();

            if (curr == end)
                break;

            foreach (var neighbor in Neighbors(curr, grid, numRows, numCols))
            {
                if (!parents.ContainsKey(neighbor))
                {
                    parents.Add(neighbor, curr);
                    queue.Enqueue(neighbor);
                }
            }
        }

        if (parents.ContainsKey(end))
        {
            var curr1 = end;
            var path = new List<(int row, int col)>();

            while (curr1 != (-1, -1))
            {
                path.Insert(0, curr1);
                curr1 = parents[curr1];
            }

            return path.Count - 1;
        }

        return int.MaxValue;
    }

    private static List<(int row, int col)> Neighbors((int row, int col) curr, char[, ] grid, int numRows, int numCols)
    {
        var neighbors = new List<(int row, int col)>();

        if (curr.row - 1 > -1 && grid[curr.row - 1, curr.col] <= grid[curr.row, curr.col] + 1)
            neighbors.Add((curr.row - 1, curr.col));
        if (curr.row  + 1 < numRows && grid[curr.row + 1, curr.col] <= grid[curr.row, curr.col] + 1)
            neighbors.Add((curr.row + 1, curr.col));
        if (curr.col - 1 > -1 && grid[curr.row, curr.col - 1] <= grid[curr.row, curr.col] + 1)
            neighbors.Add((curr.row, curr.col - 1));
        if (curr.col + 1 < numCols && grid[curr.row, curr.col + 1] <= grid[curr.row, curr.col] + 1)
            neighbors.Add((curr.row, curr.col + 1));

        return neighbors;
    }
}
