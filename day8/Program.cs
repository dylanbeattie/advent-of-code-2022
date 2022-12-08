var trees = File.ReadAllLines("input.txt")
	.Select(s => s.Select(c => c & 15).ToArray()).ToArray();

var visibleTreeCount = 0;
for (var row = 0; row < trees.Length; row++) {
	for (var col = 0; col < trees[row].Length; col++) {
        if (visible(row, col, trees)) visibleTreeCount++;
	}
}
Console.WriteLine($"Solution to part 1: {visibleTreeCount}");

int maxScenicDistance = 0;
for (var row = 0; row < trees.Length; row++) {
	for (var col = 0; col < trees[row].Length; col++) {
        var sd = scenicDistance(row, col, trees);
        if (sd > maxScenicDistance) maxScenicDistance = sd;
	}
}
Console.WriteLine($"Solution to part 2: {maxScenicDistance}");

List<int[]> findLinesOfSight(int row, int col, int[][] trees) {
    var lines = new List<int[]>();
	lines.Add(col > 0 ? trees[row][..col].Reverse().ToArray() : new int[] { });
	lines.Add(trees[row][(col + 1)..].ToArray());
	lines.Add(row > 0 ? trees[..row].Reverse().Select(c => c[col]).ToArray() : new int[] { });
	lines.Add(trees[(row + 1)..].Select(c => c[col]).ToArray());
    return lines;
}

bool visible(int row, int col, int[][] trees)
    => findLinesOfSight(row, col, trees).Any(heights 
        => heights.All(h => h < trees[row][col]));

int scenicDistance(int row, int col, int[][] trees) 
    => findLinesOfSight(row, col, trees)
        .Select(line => line.TakeUntil(h => h >= trees[row][col]).Count())
        .Aggregate(1, (x,y) => x * y, product => product);        

public static class LinqExtensions {
    public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> items, Func<T, bool> predicate) {
        bool stop = false;
        foreach(var t in items) {
            if (stop) yield break;
            stop = predicate(t);            
            yield return t;
        }
    }
}