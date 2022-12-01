var elves = File.ReadAllText("input.txt")
.Split("\n\n")
.Select(chunk => 
    chunk
        .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(Int32.Parse).Sum());

var part1 = elves.Max();
Console.WriteLine(part1);


var part2 = elves.OrderByDescending(calories => calories).Take(3).Sum();

Console.WriteLine(part2);