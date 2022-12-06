// See https://aka.ms/new-console-template for more information
var input = File.ReadAllText("input.txt");
Console.WriteLine($"Part 1: {FindMarker(input)}");
Console.WriteLine($"Part 2: {FindMarker(input, 14)}");

public static partial class Program {
	public static int FindMarker(string signal, int window = 4) {
        var i = 0;
        while(signal.Skip(i++).Take(window).ContainsDuplicates());
        return i+window-1;
    }
    
    public static bool ContainsDuplicates<T>(this IEnumerable<T> items)
        => items.Distinct().Count() != items.Count();
}
