namespace AoC_2022
{
    internal class Day3a
    {

        internal static int TheHandler(string inputPath)
        {
            var lines = File.ReadAllLines(inputPath);
            var badItemList = new List<char>();

            foreach (var line in lines)
            {
                badItemList.Add(TheErrorFinder(line));
            }

            var priorityList = ThePriorityFinder(badItemList);

            Console.WriteLine($"Sum of priorities is {priorityList.Sum()}");
            return priorityList.Sum();
        }

        private static char TheErrorFinder(string line)
        {
            var halfStringLength = line.Length / 2;
            var firstContainer = line.Substring(0, halfStringLength).ToCharArray();
            var secondContainer = line.Substring(halfStringLength).ToCharArray();

            var badItems = firstContainer.Intersect(secondContainer);

            return badItems.First();
        }

        private static List<int> ThePriorityFinder(List<char> badItemList)
        {
            var itemValueList = new List<int>();

            foreach (var item in badItemList)
            {
                int asciiValue = item;

                if (asciiValue > 96)
                    itemValueList.Add(asciiValue - 96);
                else
                    itemValueList.Add(asciiValue - 38);
            }

            return itemValueList;
        }
    }
}
