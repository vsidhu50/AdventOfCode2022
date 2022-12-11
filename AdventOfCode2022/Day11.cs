namespace AdventOfCode2022;

public class Day11
{
    public Day11()
    {
    }

    public static int PartOne()
    {
        var monkeys = new List<Monkey>();
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 80 }), x => x * 5, new Test(2, 4, 3)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 75, 83, 74 }), x => x + 7, new Test(7, 5, 6)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 86, 67, 61, 96, 52, 63, 73 }), x => x + 5, new Test(3, 7, 0)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 85, 83, 55, 85, 57, 70, 85, 52 }), x => x + 8, new Test(17, 1, 5)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 67, 75, 91, 72, 89 }), x => x + 4, new Test(11, 3, 1)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 66, 64, 68, 92, 68, 77 }), x => x * 2, new Test(19, 6, 2)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 97, 94, 79, 88 }), x => x * x, new Test(5, 2, 7)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 77, 85 }), x => x + 6, new Test(13, 4, 0)));

        for (int i = 0; i < 20; i++)
        {
            var numMonkeys = monkeys.Count;

            for (int j = 0; j < numMonkeys; j++)
            {
                var curr = monkeys[j];
                var numItems = curr._items.Count;

                for (int k = 0; k < numItems; k++)
                {
                    curr._inspected++;

                    var worryLevel = curr._items.Dequeue();
                    worryLevel = curr._operation(worryLevel);
                    worryLevel /= 3;

                    var newMonkey = curr.NewMonkey(worryLevel);
                    monkeys[newMonkey]._items.Enqueue(worryLevel);
                }
            }
        }

        return monkeys.Max(x => x._inspected) * monkeys.OrderByDescending(x => x._inspected).Skip(1).Max(x => x._inspected);
    }

    public static ulong PartTwo()
    {
        var monkeys = new List<Monkey>();

        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 80 }), x => x * 5, new Test(2, 4, 3)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 75, 83, 74 }), x => x + 7, new Test(7, 5, 6)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 86, 67, 61, 96, 52, 63, 73 }), x => x + 5, new Test(3, 7, 0)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 85, 83, 55, 85, 57, 70, 85, 52 }), x => x + 8, new Test(17, 1, 5)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 67, 75, 91, 72, 89 }), x => x + 4, new Test(11, 3, 1)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 66, 64, 68, 92, 68, 77 }), x => x * 2, new Test(19, 6, 2)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 97, 94, 79, 88 }), x => x * x, new Test(5, 2, 7)));
        monkeys.Add(new Monkey(new Queue<ulong>(new ulong[] { 77, 85 }), x => x + 6, new Test(13, 4, 0)));

        for (int i = 0; i < 10000; i++)
        {
            var numMonkeys = monkeys.Count;

            for (int j = 0; j < numMonkeys; j++)
            {
                var curr = monkeys[j];
                var numItems = curr._items.Count;

                for (int k = 0; k < numItems; k++)
                {
                    curr._inspected++;

                    var worryLevel = curr._items.Dequeue();
                    worryLevel = curr._operation(worryLevel);
                    worryLevel = worryLevel % (2 * 7 * 3 * 17 * 11 * 19 * 5 * 13);

                    var newMonkey = curr.NewMonkey(worryLevel);
                    monkeys[newMonkey]._items.Enqueue(worryLevel);
                }
            }
        }

        var max = (ulong) monkeys.Max(x => x._inspected);
        var second = (ulong) monkeys.OrderByDescending(x => x._inspected).Skip(1).Max(x => x._inspected);
        return max * second;
    }

    public class Monkey
    {
        public Queue<ulong> _items { get; set; }
        public int _inspected { get; set; }
        public Func<ulong, ulong> _operation { get; set; }
        public Test _test { get; set; }

        public Monkey(Queue<ulong> items, Func<ulong, ulong> operation, Test test)
        {
            _items = items;
            _inspected = 0;
            _operation = operation;
            _test = test;
        }

        public int NewMonkey(ulong worryLevel)
        {
            return worryLevel % _test._divisible == 0 ? _test._ifTrue : _test._ifFalse;
        }
    }

    public class Test
    {
        public ulong _divisible { get; set; }
        public int _ifTrue { get; set; }
        public int _ifFalse { get; set; }

        public Test(ulong divisible, int ifTrue, int ifFalse)
        {
            _divisible = divisible;
            _ifTrue = ifTrue;
            _ifFalse = ifFalse;
        }
    }
}
