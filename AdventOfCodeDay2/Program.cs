namespace AdventOfCodeDay2
{
    internal static class Program
    {
        private const string FilePath = @"C:\Users\robst\OneDrive\Desktop\input.txt";

        private static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        private const char opponentRock = 'A';
        private const char opponentPaper = 'B';
        private const char opponentScissors = 'C';

        private const char rock = 'X';
        private const char paper = 'Y';
        private const char scissors = 'Z';

        private const char win = 'Z';
        private const char draw = 'Y';

        private const int winningPoints = 6;
        private const int drawPoints = 3;

        static readonly Dictionary<char, char> LosingPlays = new()
        {
            [opponentRock] = scissors,
            [opponentPaper] = rock,
            [opponentScissors] = paper,
        };

        static readonly Dictionary<char, char> WinningPlays = new()
        {
            [opponentRock] = paper,
            [opponentPaper] = scissors,
            [opponentScissors] = rock,
        };

        static readonly Dictionary<char, int> MovePointValues = new()
        {
            [rock] = 1,
            [paper] = 2,
            [scissors] = 3
        };

        private static void Main(string[] args)
        {
            int part1TotalScore = 0;
            int part2TotalScore = 0;
            foreach (string round in File.ReadAllLines(FilePath))
            {
                //Part One Solution
                part1TotalScore += Part1(round);

                //Part Two Solution
                part2TotalScore += Part2(round);

            }
            Console.WriteLine($"Total Score Part 1: {part1TotalScore} Total Score Part 2: {part2TotalScore}");
            Console.ReadLine();
        }

        private static int Part1(string round)
        {
            int roundScore = 0;
            string[] plays = round.Split(" ");
            char opponentsPlay = plays[0][0];
            char myPlay = plays[1][0];
            roundScore += MovePointValues[myPlay];
            if (WinningPlays[opponentsPlay] == myPlay)
            {
                roundScore += winningPoints;
            }
            else if (alphabet[Array.FindIndex(alphabet, 0, x => x == opponentsPlay) + 23] == myPlay)
            {
                roundScore += drawPoints;
            }

            return roundScore;
        }

        private static int Part2(string round)
        {
            int roundScore = 0;
            string[] strategy = round.Split(" ");
            char opponentsPlay = strategy[0][0];
            char roundResult = strategy[1][0];

            char myPlay;
            if (roundResult == win)
            {
                myPlay = WinningPlays[opponentsPlay];
                roundScore += winningPoints;
            }
            else if (roundResult == draw)
            {
                myPlay = alphabet[Array.FindIndex(alphabet, 0, x => x == opponentsPlay) + 23];
                roundScore += drawPoints;
            }
            else
            {
                myPlay = LosingPlays[opponentsPlay];
            }
            roundScore += MovePointValues[myPlay];
            return roundScore;
        }


    }
}