var rucksacks = File.ReadAllLines("input.txt");
var part1 = rucksacks
    .Select(Bisect)
    .Select(FindCommonElement)
    .Sum(Priority);    
Console.WriteLine($"Solution to part 1: {part1}");

var part2 = rucksacks
    .Chunk(3)
    .Select(FindCommonElement)
    .Sum(Priority);    
Console.WriteLine($"Solution to part 2: {part2}");

int Priority(char c) => c - (c >= 'a' ? 96 : 38);

string[] Bisect(string s) {
    var i = s.Length / 2;
    return new[] { s.Substring(0,i), s.Substring(i) };
}

char FindCommonElement(IEnumerable<IEnumerable<char>> inputs) => inputs.Aggregate(
    inputs.First(),
    (current, next) => current.Intersect(next),
    final => final.Single());


