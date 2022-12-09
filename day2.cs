namespace AoC_2022
{
    internal class day2
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
            var yourValue = splitValues[1];

            switch (yourValue)
            {
                case "X":
                    yourValue = "A";
                    break;

                case "Y":
                    yourValue = "B";
                    break;

                case "Z":
                    yourValue = "C";
                    break;
            }

            return DetermineWinner(opponentValue, yourValue);

        }

        internal static int DetermineWinner(string opponent, string you)
        {
            var score = 0;

            switch (you)
            {
                case "A":
                    score = 1;
                    break;
                case "B":
                    score = 2;
                    break;
                case "C":
                    score = 3;
                    break;
            }

            if (opponent == you)
            {
                score += 3;
            }
            else if (opponent == "A") // Rock
            {
                if (you == "B")
                    score += 6;
                else
                    score += 0;
            }
            else if (opponent == "B") // Paper
            {
                if (you == "A")
                    score += 0;
                else
                    score += 6;
            }
            else if (opponent == "C") // Dagger
            {
                if (you == "A")
                    score += 6;
                else
                    score += 0;
            }

            return score;
        }
    }
}
