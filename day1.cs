namespace AoC_2022
{
    internal class day1
    {
        // Take input text, convert and store in a list until reaching a null line. Then send to counterator to be summed.
        // Pass that number back up to be stored in another list. When EOF, find max and return.


        public List<int> calorieTotalsList = new List<int>();

        internal static int TheHandler(string inputPath)
        {
            var lines = File.ReadAllLines(inputPath);
            var listOfSummedSnaks = new List<int>();
            var elfSnaks = new List<int>();

            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    elfSnaks.Add(int.Parse(line));
                }
                else
                {
                    listOfSummedSnaks.Add(numberMuncher(elfSnaks));
                    elfSnaks.Clear();
                }
            }

            // Find max, add to new list and remove. Repeat 2 more times, sum and return.
            var topThree = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                var currentMax = listOfSummedSnaks.Max(x => x);
                topThree.Add(currentMax);
                listOfSummedSnaks.Remove(currentMax);
            }

            return topThree.Sum();
        }

        /// <summary>
        /// A totally pointless method.
        /// </summary>
        /// <param name="snaks"></param>
        /// <returns></returns>
        internal static int numberMuncher(List<int> snaks)
        {
            return snaks.Sum();
        }
    }
}
