var top = 3;

var array = GetDatas();

var all = new List<int>();
foreach (var e in array)
{
    all.Add(e.Sum());
}

var total = 0;
for (int i = 0; i < top; i++)
{
    (int index, int capacity) = GetTop(all);
    Console.WriteLine($"{i + 1} @ {index}th. total Calories: {capacity}");

    total += capacity;
    all[index] = -1;
}

Console.WriteLine($"total: {total}");
//output:
//1 @ 49th.total Calories: 69528
//2 @ 168th.total Calories: 68878
//3 @ 89th.total Calories: 67746
//total: 206152

Span<int[]> GetDatas()
{
    var lines = File.ReadAllLines(@"./input.txt");

    int[][] array = new int[lines.Length][];

    var list = new List<int>();
    var i = 0;
    foreach (var text in lines)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            array[i] = list.ToArray();
            i++;
            list.Clear();
        }
        else
        {
            list.Add(int.Parse(text));
        }
    }

    if (!string.IsNullOrWhiteSpace(lines.Last()))
    {
        array[i] = list.ToArray();
        i++;
        list.Clear();
    }

    return array.AsSpan(0, i - 1);
}

(int index, int capacity) GetTop(List<int> list)
{
    var index = 0;
    int max = 0;
    for (int i = 0; i < list.Count; i++)
    {
        if (max < list[i])
        {
            max = list[i];
            index = i;
        }
    }

    return (index, max);
}
