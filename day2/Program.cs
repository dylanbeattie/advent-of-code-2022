var rounds = File.ReadAllLines("input.txt");

var part1 = rounds.Select(Part1Score).Sum();
Console.WriteLine($"Part 1: {part1}");

var part2 = rounds.Select(Part2Score).Sum();
Console.WriteLine($"Part 2: {part2}");

const int rock = 1;
const int paper = 2;
const int scissors = 3;
const int lose = 0;
const int win = 6;
const int draw = 3;

int Part1Score(string round) {
    var tokens = round.Split(" ");
    var them = tokens[0] switch { "A" => rock, "B" => paper, _ => scissors };
    var mine = tokens[1] switch { "X" => rock, "Y" => paper, _ => scissors };
    return (them, mine) switch {
        (rock, rock) => 4,
        (rock, paper) => 8,
        (rock, scissors) => 3,

        (paper, rock) => 1,
        (paper, paper) => draw + paper,
        (paper, scissors) => win + scissors,

        (scissors, rock) => win + rock,
        (scissors, paper) => lose + paper,
        (scissors, scissors) => draw + scissors,
        (_,_) => 0
    };
}

int Part2Score(String round) {
    var tokens = round.Split(" ");
    var them = tokens[0] switch { "A" => rock, "B" => paper, _ => scissors };
    var result = tokens[1] switch { "X" => lose, "Y" => draw, _ => win };
    var myMove = (them, result) switch {
        (rock, lose) => scissors,
        (rock, draw) => rock,
        (rock, win) => paper,

        (paper, lose) => rock,
        (paper, draw) => paper,
        (paper, win) => scissors,

        (scissors, lose) => paper,
        (scissors, win) => rock,
        (scissors, draw) => scissors,
        (_,_) => 0
    };
    return myMove + result;
}
