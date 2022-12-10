Console.WriteLine(Part1.Solve("input.txt"));

public class Part1 {
	public static int Solve(string filename) {
		var inputs = File.ReadAllLines(filename)
			.Select(line => line.Split(' '))
			.SelectMany(tokens =>
				Enumerable.Range(0, Int32.Parse(tokens[1]))
				.Select(_ => tokens[0] switch {
					"U" => (0, 1),
					"D" => (0, -1),
					"L" => (-1, 0),
					"R" => (1, 0),
					_ => (0, 0)
				})
			);
		var positions = new HashSet<(int, int)>();
		var head = (0, 0);
		var last = head;
		var tail = (0, 0);
		var offset = (0, 0);
		foreach (var move in inputs) {
			Console.WriteLine($"move is {move}");
			Console.WriteLine($"offset is {offset}");
			// move the tail
			// move the head
			// update the offset            
			var tailMove = offset switch {
				// Four cardinal direction offsets
				(-1, 0) => move switch { (+1, 0) => (+1, 0), _ => (0, 0) },
				(+1, 0) => move switch { (-1, 0) => (-1, 0), _ => (0, 0) },
				(0, -1) => move switch { (0, +1) => (0, +1), _ => (0, 0) },
				(0, +1) => move switch { (0, -1) => (0, -1), _ => (0, 0) },

				(-1, -1) => move switch { (0, +1) => (+1, +1), (+1, 0) => (+1, +1), _ => (0, 0) },
				(-1, +1) => move switch { (+1, 0) => (+1, -1), (0, -1) => (+1, -1), _ => (0, 0) },
				(+1, -1) => move switch { (-1, 0) => (-1, +1), (0, +1) => (-1, +1), _ => (0, 0) },
				(+1, +1) => move switch { (-1, 0) => (-1, -1), (0, -1) => (-1, -1), _ => (0, 0) },

				_ => (0, 0),
			};
			Console.WriteLine($"tailmove: {tailMove}");
			tail = (tail.Item1 + tailMove.Item1, tail.Item2 + tailMove.Item2);
			head = (head.Item1 + move.Item1, head.Item2 + move.Item2);
			offset = (tail.Item1 - head.Item1, tail.Item2 - head.Item2);
			for (var y = 5; y >= 0; y--) {
				for (var x = 0; x < 6; x++) {
					if (head == (x, y)) {
						Console.Write('H');
					} else if (tail == (x, y)) {
						Console.Write('T');
					} else {
						Console.Write('.');
					}
				}
				if (head == tail) Console.Write(" Head covers tail");
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine(offset);
			Console.WriteLine(String.Empty.PadLeft(60, '='));
            positions.Add(tail);
		};
		return positions.Count;
	}
}
