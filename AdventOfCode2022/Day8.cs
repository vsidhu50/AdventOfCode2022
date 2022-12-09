namespace AdventOfCode2022;

public class Day8
{
    public Day8()
    {
    }

    public static int PartOne()
    {
        var grid = Utilities.GetInputGridInts(8);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        var visible = numRows * 2 + numCols * 2 - 4;

        for (int i = 1; i < numRows - 1; i++)
            for (int j = 1; j < numCols - 1; j++)
                if (IsVisible(i, j, numRows, numCols, grid))
                    visible++;

        return visible;
    }

    public static int PartTwo()
    {
        var grid = Utilities.GetInputGridInts(8);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        var max = 0;

        for (int i = 1; i < numRows - 1; i++)
            for (int j = 1; j < numCols - 1; j++)
            {
                var score = ScenicScore(i, j, numRows, numCols, grid);
                if (score > max)
                    max = score;
            }

        return max;
    }

    private static bool IsVisible(int row, int col, int numRows, int numCols, int[,] grid)
    {
        var tree = grid[row, col];

        var up = new List<int>();
        for (int j = col - 1; j >= 0; j--)
            up.Add(grid[row, j]);

        var down = new List<int>();
        for (int j = col + 1; j < numCols; j++)
            down.Add(grid[row, j]);

        var left = new List<int>();
        for (int i = row - 1; i >= 0; i--)
            left.Add(grid[i, col]);

        var right = new List<int>();
        for (int i = row + 1; i < numRows; i++)
            right.Add(grid[i, col]);

        return up.All(x => x < tree) || down.All(x => x < tree) || left.All(x => x < tree) || right.All(x => x < tree);

    }

    private static int ScenicScore(int row, int col, int numRows, int numCols, int[,] grid)
    {
        var tree = grid[row, col];

        var up = new List<int>();

        for (int j = col - 1; j >= 0; j--)
        {
            up.Add(grid[row, j]);
            if (grid[row, j] >= tree)
                break;
        }

        var down = new List<int>();
        for (int j = col + 1; j < numCols; j++)
        {
            down.Add(grid[row, j]);
            if (grid[row, j] >= tree)
                break;
        }

        var left = new List<int>();
        for (int i = row - 1; i >= 0; i--)
        {
            left.Add(grid[i, col]);
            if (grid[i, col] >= tree)
                break;
        }

        var right = new List<int>();
        for (int i = row + 1; i < numRows; i++)
        {
            right.Add(grid[i, col]);
            if (grid[i, col] >= tree)
                break;
        }

        return up.Count * down.Count * left.Count * right.Count;
    }
}
