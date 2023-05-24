/*
 *   X  Y  Z
 * A
 * B
 * C
 */

(int scoreOne, int scoreTwo)[][] scores =
{
    new (int scoreOne, int scoreTwo)[] { (3 + 1, 3 + 1), (0 + 1, 6 + 2), (6 + 1, 0 + 3) },
    new (int scoreOne, int scoreTwo)[] { (6 + 2, 0 + 1), (3 + 2, 3 + 2), (0 + 2, 6 + 3) },
    new (int scoreOne, int scoreTwo)[] { (0 + 3, 6 + 1), (6 + 3, 0 + 2), (3 + 3, 3 + 3) }
};

//var datas = new[] { new[] { "A", "Y" }, new[] { "B", "X" }, new[] { "C", "Z" } };//test, result is 15
var datas = GetDatas();

int sumA = 0;
int sumB = 0;

foreach (var strings in datas)
{
    (int scoreOne, int scoreTwo) score = Calculate(strings[0], strings[1]);
    sumA += score.scoreOne;
    sumB += score.scoreTwo;
}

Console.WriteLine($"part1; {sumA}, {sumB}");

sumA = 0;
sumB = 0;
foreach (var strings in datas)
{
    (int scoreOne, int scoreTwo) score = CalculatePart2(strings[0], strings[1]);
    sumA += score.scoreOne;
    sumB += score.scoreTwo;
}

Console.WriteLine($"part2; {sumA}, {sumB}");

Span<string[]> GetDatas()
{
    //B Z
    //B Z
    //C Z
    var lines = File.ReadAllLines(@"./input.txt");

    string[][] array = new string[lines.Length][];

    for (var i = 0; i < lines.Length; i++)
    {
        var text = lines[i];
        if (string.IsNullOrEmpty(text.Trim()))
        {
            continue;
        }

        array[i] = text.Split(' ');
    }

    return array.AsSpan();
}

(int scoreOne, int scoreTwo) Calculate(string one, string two)
{
    int f = one switch
    {
        "A" => 0,
        "B" => 1,
        "C" => 2,
        _ => throw new ArgumentException()
    };

    int s = two switch
    {
        "X" => 0,
        "Y" => 1,
        "Z" => 2,
        _ => throw new ArgumentException()
    };

    return scores[f][s];
}

(int scoreOne, int scoreTwo) CalculatePart2(string one, string two)
{
    int f = 0;
    int s = 0;

    switch (one)
    {
        case "A":
            f = 0;
            switch (two)
            {
                case "X":
                    s = 2;
                    break;
                case "Y":
                    s = f;
                    break;
                case "Z":
                    s = 1;
                    break;
                default:
                    throw new ArgumentException();
            }
            break;
        case "B":
            f = 1;
            switch (two)
            {
                case "X":
                    s = 0;
                    break;
                case "Y":
                    s = f;
                    break;
                case "Z":
                    s = 2;
                    break;
                default:
                    throw new ArgumentException();
            }
            break;
        case "C":
            f = 2;
            switch (two)
            {
                case "X":
                    s = 1;
                    break;
                case "Y":
                    s = f;
                    break;
                case "Z":
                    s = 0;
                    break;
                default:
                    throw new ArgumentException();
            }
            break;
        default:
            throw new ArgumentException();
    }

    return scores[f][s];
}
