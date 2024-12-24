using Aoc2024;
using Aoc2024.Logging;

namespace Aoc2024
{

	public class InputDataDay02 : InputDataDayXX
	{
		public InputDataDay02(InputDataType dataType, string idx) : base(AocDay.Day02, dataType, "\n", idx)
		{
			rawData.Remove("");
			//string[] lines = rawData.Split();
		}

		static int CountSafeReports(List<string> data)
		{
			int numOfSafeReports = 0;
			foreach (var line in data)
			{
				var trimmedData = line.Trim();
				// Split the string into parts by spaces
				var partsOfTrimmedData = trimmedData.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				// Convert each part to an integer
				var numbers = partsOfTrimmedData.Select(p => int.Parse(p)).ToList();
				bool equalNumFlag = CheckForEqualNumbers(numbers);
				if (equalNumFlag)
					continue;
				numOfSafeReports += CheckForIncreasingNumbers(numbers);
				numOfSafeReports += CheckForDecreasingNumbers(numbers);
			}
			return numOfSafeReports;
		}
		static int CheckForIncreasingNumbers(List<int> ListOfNumbers)
		{
			// Check if each number is greater than the previous one
			for (int i = 1; i < ListOfNumbers.Count; i++)
			{
				if ((ListOfNumbers[i] < ListOfNumbers[i - 1]) && (Math.Abs(ListOfNumbers[i] - ListOfNumbers[i - 1]) <= 3))
					return 0;
			}
			return 1;
		}
		static int CheckForDecreasingNumbers(List<int> ListOfNumbers)
		{
			// Check if each number is greater than the previous one
			for (int i = 1; i < ListOfNumbers.Count; i++)
			{
				if ((ListOfNumbers[i] > ListOfNumbers[i - 1]) && (Math.Abs(ListOfNumbers[i] - ListOfNumbers[i - 1]) <= 3))
					return 0;
			}
			return 1;
		}
		static bool CheckForEqualNumbers(List<int> ListOfNumbers)
		{
			bool foundEqualNumber = false;
			for (int i = 0; i < ListOfNumbers.Count - 1; i++)
			{
				if (ListOfNumbers[i] == ListOfNumbers[i + 1])
					foundEqualNumber = true;
			}
			return foundEqualNumber;
		}

		protected int SolvePart1()
		{
			int safeReports = CountSafeReports(this.rawData);
			return safeReports;
		}
		public override string SolutionToPart1
		{
			get
			{
				logger.LogInformation("Solving Part 1");
				return SolvePart1().ToString();
			}
		}

		//public override string SolutionToPart2 => throw new NotImplementedException();

	}
}
