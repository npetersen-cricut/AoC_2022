namespace AoC_2022
{
    internal class Day3b
    {
        internal static int TheHandler(string inputPath)
        {
            var lines = File.ReadAllLines(inputPath);
            var commonElementList = new List<char>();

            var count = 0;
            var passingList = new List<string>();

            foreach (var line in lines)
            {
                passingList.Add(line);

                if (++count == 3)
                {
                    commonElementList.Add(TheComparer(
                        passingList[0].ToCharArray(),
                        passingList[1].ToCharArray(),
                        passingList[2].ToCharArray()
                        ));
                    passingList.Clear();
                    count = 0;
                }

            }


            var priorityList = ThePriorityFinder(commonElementList);

            Console.WriteLine($"Sum of priorities is {priorityList.Sum()}");
            return priorityList.Sum();
        }

        private static char TheComparer(char[] firstPackContents, char[] secondPackContents, char[] thirdElf)
        {
            var commonItem = new List<char>();

            var firstSet = new HashSet<char>();
            var secondSet = new HashSet<char>();
            var thirdSet = new HashSet<char>();

            for (int i = 0; i < firstPackContents.Length; i++)
            {
                firstSet.Add(firstPackContents[i]);
            }
            for (int i = 0; i < secondPackContents.Length; i++)
            {
                secondSet.Add(secondPackContents[i]);
            }


            for (int i = 0; i < thirdElf.Length; i++)
            {
                if (firstSet.Contains(thirdElf[i])
                    && secondSet.Contains(thirdElf[i]))
                {
                    if (!thirdSet.Contains(thirdElf[i]))
                    {
                        commonItem.Add(thirdElf[i]);
                    }

                    thirdSet.Add(thirdElf[i]);
                }
            }

            return commonItem.First();
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
