// Read all lines into an array of strings
var rucksacks = File.ReadAllLines("input.txt");
// var rucksacks = @"vJrwpWtwJgWrhcsFMMfFFhFp
// jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
// PmmdzqPrVvPwwTWBwg
// wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
// ttgJtRGJQctTZtZT
// CrZsJsPPZsGzwwsLwLmpwMDw".Split(Environment.NewLine);

// split each line into two halves
// Find the element that's common to both halves of the line
var part1Elements = rucksacks.Select(FindCommonElement1);
var totalPriority = part1Elements.Sum(Priority);
Console.WriteLine($"Solution to part 1: {totalPriority}");

var trios = rucksacks.Chunk(3);
var elements2 = trios.Select(FindCommonElement2);
var part2 = elements2.Sum(Priority);
Console.WriteLine($"Solution to part 2: {part2}");

int Priority(char c) {
    if (c >= 'a' && c <= 'z') return c - 'a' + 1;
    if (c >= 'A' && c <= 'Z') return c - 'A' + 27;
    return 0;
}
char FindCommonElement2(string[] lines) {
    return lines[0].Intersect(lines[1]).Intersect(lines[2]).Single();
}

char FindCommonElement1(string line) {
    var halfLength = line.Length / 2;
    var firstHalf = line.Substring(0, halfLength);
    var secondHalf = line.Substring(halfLength);
    var common = firstHalf.Intersect(secondHalf).Single();
    return common;
}