var input = File.ReadAllLines("input.txt");
var s = 0;
var ticks = Execute(input).ToArray();
for (var tick = 19; tick < ticks.Length; tick += 40) {
	s += ticks[tick].Item2 * ticks[tick].Item1;
}
Console.WriteLine(s);

var rows = ticks
    .Select(tuple => Math.Abs(tuple.Item2 - ((tuple.Item1-1) % 40)) < 2)
    .Select(p => p ? '█' : ' ')
    .Chunk(40);

foreach(var row in rows) Console.WriteLine(row);

IEnumerable<(int, int)> Execute(string[] program) {
	int x = 1;
	int c = 0;
	foreach (var op in program.Select(line => line.Split(' '))) {
		switch (op[0]) {
			case "noop":
				yield return (++c, x);
				break;
			case "addx":
				yield return (++c, x);
				yield return (++c, x);
				x += Int32.Parse(op[1]);
				break;
		}
	}
}

