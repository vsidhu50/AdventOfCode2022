namespace AdventOfCode2022;

public class Day7
{
    public Day7()
    {
    }

    public static int PartOne()
    {
        var input = Utilities.GetInputLines(7);

        Item curr = null;
        Item root = null;

        foreach (var line in input)
        {
            // parsing command
            if (line[0] == '$')
            {
                var command = line.Split(' ')[1];

                // if changing directory need to update curr
                if (command == "cd")
                {
                    var directory = line.Split(' ')[2];

                    // update curr to root
                    if (directory == "/")
                    {
                        // create root if null
                        if (root == null)
                            root = new Item(null, new Dictionary<string, Item>(), 0);

                        curr = root;
                    }
                    // update curr to parent
                    else if (directory == "..")
                        curr = curr._parent;
                    // update curr to whatever directory is named
                    else
                        curr = curr._children.First(x => x.Key == directory).Value;
                }
            }
            // parsing output
            else
            {
                var first = line.Split(' ')[0];
                var second = line.Split(' ')[1];

                // found directory, see if it's new
                if (first == "dir")
                {
                    // if directory has not  been encountered, we need to add to children of curr
                    if (!curr._children.ContainsKey(second))
                    {
                        var newDir = new Item(curr, new Dictionary<string, Item>(), 0);
                        curr._children.Add(second, newDir);
                    }
                }
                // found file, see if it's new
                else
                {
                    // if file has not  been encountered, we need to add to children of curr
                    if (!curr._children.ContainsKey(second))
                    {
                        var newFile = new Item(curr, null, int.Parse(first));
                        curr._children.Add(second, newFile);
                    }
                }
            }
        }

        CalcSizes(root);

        return SumLimit(100000, root);
    }

    public static int PartTwo()
    {
        var input = Utilities.GetInputLines(7);

        Item curr = null;
        Item root = null;

        foreach (var line in input)
        {
            // parsing command
            if (line[0] == '$')
            {
                var command = line.Split(' ')[1];

                // if changing directory need to update curr
                if (command == "cd")
                {
                    var directory = line.Split(' ')[2];

                    // update curr to root
                    if (directory == "/")
                    {
                        // create root if null
                        if (root == null)
                            root = new Item(null, new Dictionary<string, Item>(), 0);

                        curr = root;
                    }
                    // update curr to parent
                    else if (directory == "..")
                        curr = curr._parent;
                    // update curr to whatever directory is named
                    else
                        curr = curr._children.First(x => x.Key == directory).Value;
                }
            }
            // parsing output
            else
            {
                var first = line.Split(' ')[0];
                var second = line.Split(' ')[1];

                // found directory, see if it's new
                if (first == "dir")
                {
                    // if directory has not  been encountered, we need to add to children of curr
                    if (!curr._children.ContainsKey(second))
                    {
                        var newDir = new Item(curr, new Dictionary<string, Item>(), 0);
                        curr._children.Add(second, newDir);
                    }
                }
                // found file, see if it's new
                else
                {
                    // if file has not  been encountered, we need to add to children of curr
                    if (!curr._children.ContainsKey(second))
                    {
                        var newFile = new Item(curr, null, int.Parse(first));
                        curr._children.Add(second, newFile);
                    }
                }
            }
        }

        CalcSizes(root);

        var unusedSpace = 70000000 - root._size;
        var minDelete = 30000000 - unusedSpace;

        return MinLimit(minDelete, root);
    }

    public class Item
    {
        public Item? _parent { get; set; }

        public Dictionary<string, Item>? _children { get; set; }

        public int _size { get; set; }

        public Item(Item? parent, Dictionary<string, Item>? children, int size)
        {
            _parent = parent;
            _children = children;
            _size = size;
        }
    }

    public static int CalcSizes(Item curr)
    {
        if (curr._children != null)
        {
            curr._size = curr._children.Values.Sum(x => CalcSizes(x));
            return curr._size;
        }
        return curr._size;
    }

    public static int SumLimit(int limit, Item curr)
    {
        if (curr._children != null && curr._size <= limit)
            return curr._size + curr._children.Values.Sum(x => SumLimit(limit, x));
        else if (curr._children != null && curr._size > limit)
            return curr._children.Values.Sum(x => SumLimit(limit, x));
        return 0;
    }

    public static int MinLimit(int limit, Item curr)
    {
        if (curr._children != null && curr._size >= limit)
            return int.Min(curr._size, curr._children.Values.Min(x => MinLimit(limit, x)));
        else if (curr._children != null && curr._size > limit)
            return curr._children.Values.Min(x => MinLimit(limit, x));
        return int.MaxValue;
    }
}
