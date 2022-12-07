using Day7;

var input = File.ReadAllLines("input.txt");
var fs = FileTree.Parse(input);

var part1 = fs.AllSizes
	.Where(size => size <= 100000).Sum();
Console.WriteLine($"Solution to part 1: {part1}");

var totalDiskSize = 70_000_000;
var required = 30_000_000;
var currentlyUsed = fs.Size;
var needToDelete = currentlyUsed - (totalDiskSize - required);
Console.WriteLine($"Currently using: {currentlyUsed}");
Console.WriteLine($"Need to delete at least: {needToDelete}");

var directoriesThatWouldDoTheTrick = fs.AllSizes.Where(s => s >= needToDelete);
var part2 = directoriesThatWouldDoTheTrick.Min();
Console.WriteLine($"Solution to part 2: {part2}");







