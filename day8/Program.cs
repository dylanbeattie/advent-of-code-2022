var trees = File.ReadAllLines("example.txt")
	.Select(s => s.Select(c => c & 15).ToArray()).ToArray();

var visibles = 0;
for (var row = 0; row < trees.Length; row++) {
	for (var col = 0; col < trees[row].Length; col++) {
		Console.Write(visible(row, col, trees) ? 'X' : ' ');
	}
	Console.WriteLine();
	// if (visible(row,col,trees)) visibles++;
}

Console.WriteLine(visibles);

bool visible(int row, int col, int[][] trees) {
	var lines = new List<int[]>();
	if (col > 0) lines.Add(trees[row][..(col - 1)]);
	if (col + 1 < trees[row].Length) lines.Add(trees[row][(col + 1)..]);
	if (row > 0) lines.Add(trees[..(row - 1)].Select(c => c[col]).ToArray());
	if (row + 1 < trees.Length) lines.Add(trees[(row + 1)..].Select(c => c[col]).ToArray());
	return lines.Any(heights => heights.All(h => h < trees[row][col]));
}
