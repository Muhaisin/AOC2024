using System.ComponentModel;
using System.Text.RegularExpressions;
using Aoc2024;

namespace Aoc2024
{

    public class InputDataDay03 : InputDataDayXX
    {
        public InputDataDay03(InputDataType dataType, string idx) : base(AocDay.Day03, dataType, "\n", idx)
        {
            rawData.Remove("");

        }
        //Find mul(x,Y). Then extract extract x and y. then multiply x and y. Then store them in a container



        static List<List<int>> FindIntegers(List<Match> matches)
        {
            List<List<int>> integerList = new List<List<int>>();
            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                integerList.Add(new List<int> { x, y });
            }
            return integerList;
        }
        static int FindSumOfProducts(List<List<int>> listOfIntegers)
        {
            int sumOfProds = 0;
            foreach (List<int> values in listOfIntegers)
            {
                sumOfProds += values[0] * values[1];
            }
            return sumOfProds;
        }
        static List<Match> FindMatches(List<string> data)
        {
            string pattern = @"mul\((\d+),(\d+)\)";
            List<Match> matchedStrings = new List<Match>();
            foreach (string line in data)
            {
                MatchCollection matches = Regex.Matches(line, pattern);
                foreach (Match match in matches)
                {
                    matchedStrings.Add(match);
                }

            }
            return matchedStrings;
        }

        protected int SolvePart1()
        {

            List<Match> foundMatches = FindMatches(this.rawData);
            List<List<int>> valuesToMultiply = FindIntegers(foundMatches);
            int sumProds = FindSumOfProducts(valuesToMultiply);
            return sumProds;
        }
        public override string SolutionToPart1
        {
            get
            {
                logger.LogInformation("Solving Part 1 ");
                return SolvePart1().ToString();
            }
        }

        public override string SolutionToPart2 => throw new NotImplementedException();

    }
}
