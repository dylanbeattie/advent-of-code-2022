var inputs = File.ReadAllLines("input.txt");
var crates = inputs.TakeWhile(line => line != "")
	.Select(line => line.Chunk(4).Select(chars => chars[1]).ToArray())
	.Reverse().ToArray();

var moves = inputs.SkipWhile(line => line != "").Skip(1)
	.Select(line => line.Split(' '))
	.Select(tokens => new[] { tokens[1], tokens[3], tokens[5] }.Select(Int32.Parse).ToArray())
	.Select(ints => (ints[0], ints[1] - 1, ints[2] - 1));

var stacks1 = crates[0].Select(_ => new Stack<char>()).ToArray();
foreach (var line in crates[1..]) {
	for (var i = 0; i < stacks1.Length; i++) {
        if (line[i] != ' ') stacks1[i].Push(line[i]);
    }
}

var stacks2 = stacks1.Select(t => new Stack<char>(t.Reverse())).ToArray();

foreach (var (count, source, target) in moves) {
	for(var i = 0; i < count; i++) stacks1[target].Push(stacks1[source].Pop());
}
Console.WriteLine($"Solution to part 1: {Stringify(stacks1)}");

foreach (var (count, source, target) in moves) {
    stacks2[target].Push(stacks2[source].Pop(count));
}
Console.WriteLine($"Solution to part 2: {Stringify(stacks2)}");

string Stringify(Stack<char>[] stacks) => new String(stacks.Select(stack => stack.Peek()).ToArray());

static class StackExtensions {
	public static IEnumerable<T> Pop<T>(this Stack<T> stack, int count) {
		for (var i = 0; i < count; i++) yield return stack.Pop();
	}
	public static void Push<T>(this Stack<T> stack, IEnumerable<T> items) {
		foreach (var item in items.Reverse()) stack.Push(item);
	}
}