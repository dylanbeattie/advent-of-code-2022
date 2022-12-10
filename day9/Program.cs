Console.WriteLine(Day9.Solve("input.txt"));
Console.WriteLine(Day9.Solve("input.txt", 10));

public class Day9 {
    public static int Solve(string filename, int knotCount = 2)
        => SimulateRope(ReadMoves(filename), knotCount);
    
	private static IEnumerable<(int, int)> ReadMoves(string filename)
		=> File.ReadAllLines(filename)
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

	public static int SimulateRope(IEnumerable<(int, int)> moves, int knotCount = 1) {
        var visited = new HashSet<(int,int)>();
        var origin = (0,0);
        visited.Add(origin);
		var knots = Enumerable.Repeat(origin, knotCount).ToArray();
		foreach (var move in moves) {
            // foreach(var knot in knots) Console.Write(knot.ToString().PadRight(12));
            // Console.WriteLine();
            knots[0] = Move(knots[0], move);
            for(var i = 1; i < knotCount; i++) {
                knots[i] = Follow(knots[i-1], knots[i]);
            }
            visited.Add(knots[^1]);
            /*
            for(var y = 15; y >= -6; y--) {
                for(var x = -10; x < 11; x++) {
                    for(var i = 0; i < knots.Length; i++) {
                        if (knots[i] == (x,y)) {
                            Console.Write(i == 0 ? "H" : i.ToString());
                            goto nextColumn;
                        }
                    }
                    Console.Write('.');                    
                   nextColumn: {}
                }
                Console.WriteLine();
            }
            Console.ReadKey(true);
            */
		}
        return visited.Count();
	}

    public static (int,int) Follow((int,int) head, (int,int) tail) {
        var offset = (tail.Item1 - head.Item1, tail.Item2 - head.Item2);
        return offset switch {
            (-2,-2) => (tail.Item1+1, tail.Item2+1),
            (-2,-1) => (tail.Item1+1, tail.Item2+1),
            (-2,+0) => (tail.Item1+1, tail.Item2),
            (-2,+1) => (tail.Item1+1, tail.Item2-1),
            (-2,+2) => (tail.Item1+1, tail.Item2-1),

            (+2,-2) => (tail.Item1-1, tail.Item2+1),
            (+2,-1) => (tail.Item1-1, tail.Item2+1),
            (+2,+0) => (tail.Item1-1, tail.Item2),
            (+2,+1) => (tail.Item1-1, tail.Item2-1),
            (+2,+2) => (tail.Item1-1, tail.Item2-1),

            (-1,-2) => (tail.Item1+1, tail.Item2+1),
            (+0,-2) => (tail.Item1, tail.Item2+1),
            (+1,-2) => (tail.Item1-1, tail.Item2+1),

            (-1,+2) => (tail.Item1+1, tail.Item2-1),
            (+0,+2) => (tail.Item1, tail.Item2-1),
            (+1,+2) => (tail.Item1-1, tail.Item2-1),
            _ => tail
        };
    }

    public static (int,int) Move((int,int) head, (int,int) move) 
        => (head.Item1 + move.Item1, head.Item2 + move.Item2);

}
