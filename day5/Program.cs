(Stack<char>[], IEnumerable<(int,int,int)>) ReadInputs(string filename) {
    var inputs = File.ReadAllLines(filename);

    var stackLines = inputs.TakeWhile(line => line != "")
        .Select(line => line.Chunk(4).Select(chunk => chunk[1]).ToArray())
        .Reverse().ToArray();

    var stacks = stackLines[0].Select(_ => new Stack<char>()).ToArray();
    foreach(var line in stackLines[1..]) {
        for(var i = 0; i < stacks.Length; i++) if (line[i] != ' ') stacks[i].Push(line[i]);
    }

    var moves = inputs.SkipWhile(line => line != "").Skip(1)
        .Select(line => line.Split(' '))
        .Select(tokens => new[] { tokens[1], tokens[3], tokens[5] }.Select(Int32.Parse).ToArray())
        .Select(ints => (ints[0],ints[1]-1,ints[2]-1));

    return (stacks, moves);
}
var filename = "input.txt";
var (stacks, moves) = ReadInputs(filename);
foreach(var (count,source,target) in moves) {
    var i = 0;
    while (i++ < count) stacks[target].Push(stacks[source].Pop());
}
var part1 = new String(stacks.Select(stack => stack.Peek()).ToArray());;
Console.WriteLine($"Solution to part 1: {part1}");

(stacks, moves) = ReadInputs(filename);
foreach(var (count,source,target) in moves) {
    stacks[target].Push(stacks[source].Pop(count));
}

var part2 = new String(stacks.Select(stack => stack.Peek()).ToArray());;
Console.WriteLine($"Solution to part 2: {part2}");

static class StackExtensions {
    public static IEnumerable<T> Pop<T>(this Stack<T> stack, int count) {
        for(var i = 0; i < count; i++) yield return stack.Pop();
    }
    public static void Push<T>(this Stack<T> stack, IEnumerable<T> items) {
        foreach(var item in items.Reverse()) stack.Push(item);
    }
}