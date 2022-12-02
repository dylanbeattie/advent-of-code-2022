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
        (rock, rock) => draw + rock,
        (rock, paper) => win + paper,
        (rock, scissors) => lose + scissors,

        (paper, rock) => lose + rock,
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
    return (them, result) switch {
        (rock, lose) => lose + scissors,
        (rock, draw) => draw + rock,
        (rock, win) => win + paper,

        (paper, lose) => lose + rock,
        (paper, draw) => draw + paper,
        (paper, win) => win + scissors,

        (scissors, lose) => lose + paper,
        (scissors, win) => win + rock,
        (scissors, draw) => draw + scissors,
        (_,_) => 0
    };
}
