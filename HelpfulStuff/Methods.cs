using System.Text.RegularExpressions;

namespace HelpfulStuff
{
    public static class Methods
    {
        public static int[] InputToIntArray(string path)
        {
            List<int> inputs = new List<int>();
            foreach(var input in File.ReadLines(path))
            {
                if(int.TryParse(input, out int numToAdd))
                {
                    inputs.Add(numToAdd);
                }
            }
            return inputs.ToArray();
        }

        public static int Sum(in int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result += nums[i];
            }
            return result;
        }

        public static int CountIncreaseFromRange(string path, int range)
        {
            var input = InputToIntArray(path);
            int increases = 0;

            int rangeSum = 0;
            int lastRangeSum = 0;
            for (int i = 0; i < input.Length - range; i++)
            {
                rangeSum = Sum(input[i..(i + range)]);
                if (rangeSum > lastRangeSum) { increases++; }
                lastRangeSum = rangeSum;
            }

            return increases;
        }

        public static int GetPosition(string path)
        {
            int forward = 0;
            int depth = 0;
            int aim = 0;
            foreach(var input in File.ReadAllLines(path))
            {
                var dirGetter = Regex.Match(input, @"\d+").Value;
                int x = int.Parse(dirGetter);
                if (input.Contains("forward") )
                {
                    forward += x;
                    depth += (aim * x);
                }
                else if (input.Contains("down"))
                {
                    // depth += x;
                    aim += x;
                }
                else if (input.Contains("up"))
                {
                    // depth -= x;
                    aim -= x;
                }
            }
            
            return forward * depth;
        }

        public static int AddArrayColumn(string path, int matchOne, int matchTwo)
        {
            // read in file
            // make a 2d array
            for (int i = 0; i < length; i++)
            {
                // sum by column
                // if matchOne ++
                // if matchTwo ++

            }
            return total;
        }
    }
}