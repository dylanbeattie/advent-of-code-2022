// // See https://aka.ms/new-console-template for more information
// ROCK A     0001
// Paper B    0010
// Scissors C 0011

// rr => 0001 0000 => 0
// rp => 0001 0001 => -1
// rs => 0001 0010 => 1
// pr => 0010 0000 => 1
// pp => 0010 0001 => 0
// ps => 0010 0010 => -1
// sr => 0011 0000 => -1
// sp => 0011 0001 => 1
// ss => 0011 0010 => 0

//                          &    ^
// rr => 0001 1000 => 0     00  
// pp => 0010 1001 => 0     00
// ss => 0011 1010 => 0     10
// rs => 0001 1010 => 1     00
// pr => 0010 1000 => 1     00
// sp => 0011 1001 => 1     01    
// rp => 0001 1001 => -1    01
// ps => 0010 1010 => -1    00
// sr => 0011 1000 => -1    00


// 0010 0001 => 
// rock loses to paper 0001 + 0010 = A < B
// paper loses to scissors = 0010 < 0011 = A < bits
// scissors loses to rock = 0011 % 3 < 0001

Console.WriteLine("Mine    Theirs  |       &       ^       <<2 ^"); 
foreach (var m in "ABC") {
	foreach (var t in ("XYZ")) {
		Console.Write($"{bits(m)} {bits(t)}");
		foreach (var op in new Func<int, int, int>[] {
				(x,y) => x | y,
				(x,y) => x & y,
				(x,y) => x ^ y,
				(x,y) => (x << 2 ^ y) & 15
			}) {
			Console.Write(" " + bits(op(m, t)).PadLeft(7, '0'));
		}
		Console.WriteLine();
	}
}

string bits(int i) => Convert.ToString(i, 2);