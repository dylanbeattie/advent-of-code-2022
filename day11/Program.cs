//var monkeys = File.ReadAllText("example.txt")
//	.Split(Environment.NewLine + Environment.NewLine)
//	.Select(Monkey.Parse)
//	.ToList();

//for (var i = 0; i <= 19; i++) {
//	foreach (var monkey in monkeys) {
//		while (monkey.Items.TryDequeue(out var item)) {
//			item = monkey.Operation(item);
//			item = (Int64) (item / (Int64)3);
//			monkeys[monkey.Test(item) ? monkey.TrueMonkey : monkey.FalseMonkey].Items.Enqueue(item);
//		}
//	}
//	Console.WriteLine($"After round {i+1}:");
//	for (var m = 0; m < monkeys.Count; m++) Console.WriteLine($"Monkey {m}: {monkeys[m]}");
//}
//for (var m = 0; m < monkeys.Count; m++) Console.WriteLine($"Monkey {m} inspected items {monkeys[m].InspectionCount} times");

//var part1 = monkeys
//	.OrderByDescending(m => m.InspectionCount)
//	.Take(2)
//	.Aggregate(Int64.Parse("1"), (i, m) => i * m.InspectionCount);

//Console.WriteLine($"Solution to part 1: {part1}");

using System.Numerics;

var monkeys = File.ReadAllText("example.txt")
	.Split(Environment.NewLine + Environment.NewLine)
	.Select(Monkey.Parse)
	.ToList();

for (var i = 0; i < 10000; i++) {
	foreach (var monkey in monkeys) {
		while (monkey.Items.TryDequeue(out var item)) {
			item = monkey.Operation(item);
			monkeys[monkey.Test(item) ? monkey.TrueMonkey : monkey.FalseMonkey].Items.Enqueue(item);
		}
	}

	Console.Write(".");
	if (i % 50 == 0) Console.WriteLine();
	if (new[] { 1, 20, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 }.Contains(i+1)) {
		Console.WriteLine($"After round {i+1}:");
		for (var m = 0; m < monkeys.Count; m++) Console.WriteLine($"Monkey {m} inspected items {monkeys[m].InspectionCount} times");
		for (var m = 0; m < monkeys.Count; m++) Console.WriteLine($"Monkey {m}: {monkeys[m]}");
	}
}

for (var m = 0; m < monkeys.Count; m++) Console.WriteLine($"Monkey {m} inspected items {monkeys[m].InspectionCount} times");
var part2 = monkeys
	.OrderByDescending(m => m.InspectionCount)
	.Take(2)
	.Aggregate(BigInteger.Parse("1"), (i, m) => i * m.InspectionCount);
Console.WriteLine($"Solution to part 2: {part2}");

public class Monkey {
	
	public override string ToString() => String.Join(", ", Items.ToArray());

	public Queue<BigInteger> Items { get; set; } = new();
	public Func<BigInteger, BigInteger> Operation { get; set; } = _ => 0;
	private Func<BigInteger, bool> test = _ => true;
	public BigInteger InspectionCount { get; private set; }
	public bool Test(BigInteger item) {
		InspectionCount++;
		return test(item);
	}
	public int TrueMonkey { get; set; }
	public int FalseMonkey { get; set; }

	public static Monkey Parse(string input) {
		var lines = input.Split(Environment.NewLine).Select(line => line.Trim());
		var monkey = new Monkey();
		foreach (var line in lines) {
			var tokens = line.Split(new [] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			if (tokens.Length == 0) continue;
			Console.WriteLine(String.Join("|",tokens));
			switch (tokens[0]) {
				case "Starting":
					monkey.Items = new Queue<BigInteger>(tokens[2..].Select(BigInteger.Parse));
					break;
				case "Operation:":
					BigInteger.TryParse(tokens[5], out var y);
					monkey.Operation = tokens[4] switch {
						"+" => tokens[5] == "old" ? x => x + x : x => x + y,
						"*" => tokens[5] == "old" ? x => x * x : x => x * y,
						_ => monkey.Operation
					};
					break;
				case "Test:":
					var factor = BigInteger.Parse(tokens[3]);
					monkey.test = x => x % factor == 0;
					break;
				case "If":
					var target = Int32.Parse(tokens[5]);
					switch (tokens[1]) {
						case "true:":
							monkey.TrueMonkey = target;
							break;
						case "false:":
							monkey.FalseMonkey = target;
							break;
					}
					break;
			}
		}

		return monkey;
	}
}

public class Tests {
	[Fact]
	public void Test1() {
		1.ShouldBe(2);
	}
}
