// See https://aka.ms/new-console-template for more information
var input = File.ReadAllText("input.txt");
Console.WriteLine($"Part 1: {input.FindMarker()}");
Console.WriteLine($"Part 2: {input.FindMarker(14)}");

public static class Extensions {
	public static int FindMarker(this string signal, int window = 4) {
        var i = 0;
        while(! signal.Skip(i++).Take(window).IsSet());
        return i+window-1;
    }
    
    public static bool IsSet<T>(this IEnumerable<T> items)
        => items.Distinct().Count() == items.Count();
}
