var inputs = File.ReadAllLines("input.txt")
    .Select(Tokenize).Select(Chunkify); 

Console.WriteLine($"Part 1: {inputs.Where(Includes).Count()}");
Console.WriteLine($"Part 2: {inputs.Where(Overlaps).Count()}");

int[] Tokenize(string line) 
    => line.Split(',', '-').Select(Int32.Parse).ToArray();

IEnumerable<int>[] Chunkify(int[] ints)
    => ints.Chunk(2).Select(pair 
        => Enumerable.Range(pair[0], pair[1] - pair[0] + 1)).ToArray();

bool Includes(IEnumerable<int>[] ranges)
    => ranges.Select(r => r.Count())
        .Contains(ranges[0].Intersect(ranges[1]).Count());

bool Overlaps(IEnumerable<int>[] ranges) 
    => ranges[0].Intersect(ranges[1]).Any();
