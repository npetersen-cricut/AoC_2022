namespace AoC_2022
{
    internal class day2b
    {
        /* Guide:
         * A/Y = Rock = 1 pt.
         * B/X = Paper = 2 pt.
         * C/Z = Scissors = 3 pt.
         *
         * Score is your shape (second column) + outcome score
         * loss = 1, tie = 3, win = 6
         *
         * Tabulate each row and then sum.
         */

        // First write logic to figure out outcome of match and score.

        // First take line input and split into two values.
        internal static int TheHandler(string input)
        {
            var inputFile = File.ReadAllLines(input);
            var scoresList = new List<int>();

            foreach (var line in inputFile)
            {
                // Take input in format "x y", split, and pass to new function.
                // That new function will ask method to determine outcome
                scoresList.Add(TheConverter(line));
            }

            var sumTotal = scoresList.Sum();
            Console.WriteLine($"The total score for input is {sumTotal} points.");
            return sumTotal;
        }

        internal static int TheConverter(string line)
        {
            var splitValues = line.Split(' ');
            var opponentValue = splitValues[0];
            var outcomeValue = splitValues[1];



            return DetermineStrategy(opponentValue, outcomeValue);

        }

        internal static int DetermineStrategy(string opponent, string outcome)
        {
            var score = 0;

            switch (outcome)
            {
                case "X": // Lose
                    score = 0;

                    if (opponent == "A")
                        score += 3;
                    else if (opponent == "B")
                        score += 1;
                    else
                        score += 2;
                    break;

                case "Y":  // Tie
                    score = 3;
                    if (opponent == "A")
                        score += 1;
                    else if (opponent == "B")
                        score += 2;
                    else
                        score += 3;

                    break;

                case "Z":  // Win
                    score = 6;

                    if (opponent == "A")
                        score += 2;
                    else if (opponent == "B")
                        score += 3;
                    else
                        score += 1;
                    break;
            }

            return score;
        }
    }
}
