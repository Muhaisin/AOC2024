using System.Diagnostics.Metrics;
using Aoc2024;
using Aoc2024.Logging;

namespace Aoc2024
{

	public class InputDataDay02 : InputDataDayXX
	{
		public InputDataDay02(InputDataType dataType, string idx) : base(AocDay.Day02, dataType, "\n", idx)
		{
			rawData.Remove("");
		}

		// static int CountSafeReports(List<string> data)
		// {
		// 	int numOfSafeReports = 0;
		// 	foreach (var line in data)
		// 	{
		// 		var trimmedData = line.Trim();
		// 		// Split the string into parts by spaces
		// 		var partsOfTrimmedData = trimmedData.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
		// 		// Convert each part to an integer
		// 		var numbers = partsOfTrimmedData.Select(p => int.Parse(p)).ToList();
		// 		bool equalNumFlag = CheckForEqualNumbers(numbers);
		// 		if (equalNumFlag)
		// 			continue;
		// 		numOfSafeReports += CheckForIncreasingNumbers(numbers);
		// 		numOfSafeReports += CheckForDecreasingNumbers(numbers);
		// 	}
		// 	return numOfSafeReports;
		// }
		// static int CheckForIncreasingNumbers(List<int> ListOfNumbers)
		// {
		// 	List<int> workingList = new List<int>(ListOfNumbers);
		// 	int counter = 0;
		// 	// Check if each number is greater than the previous one
		// 	for (int i = 1; i < workingList.Count; i++)
		// 	{
		// 		bool badLevelFound = FindIncreasingBadLevel(workingList[i - 1], workingList[i]);
		// 		if (badLevelFound)
		// 		{
		// 			counter += 1;
		// 			if (counter > 1)
		// 				return 0;
		// 			else
		// 			{
		// 				workingList.RemoveAt(i);
		// 				i--;
		// 				continue;
		// 			}
		// 		}
		// 	}
		// 	// If the loop completes without returning 0, return 1 (list is increasing with the condition)
		// 	return 1;
		// }
		// static int CheckForDecreasingNumbers(List<int> ListOfNumbers)
		// {
		// 	List<int> workingList = new List<int>(ListOfNumbers);
		// 	int counter = 0;
		// 	for (int i = 1; i < workingList.Count; i++)
		// 	{
		// 		bool badLevelFound = FindDecreasingBadLevel(workingList[i - 1], workingList[i]);
		// 		if (badLevelFound)
		// 		{
		// 			counter += 1;
		// 			if (counter > 1)
		// 				return 0;
		// 			else
		// 			{
		// 				workingList.RemoveAt(i);
		// 				i--;
		// 				continue;
		// 			}
		// 		}

		// 	}
		// 	return 1;
		// }
		// static bool FindDecreasingBadLevel(int prev, int curr)
		// {
		// 	bool badLevel = false;
		// 	if ((curr > prev) || (Math.Abs(curr - prev) > 3))
		// 		badLevel = true;
		// 	return badLevel;
		// }
		// static bool FindIncreasingBadLevel(int prev, int curr)
		// {
		// 	// If the current number is not greater than the previous one OR the difference is greater than 3, return false;
		// 	bool badLevel = false;
		// 	if (curr < prev || Math.Abs(curr - prev) > 3)
		// 		badLevel = true;
		// 	return badLevel;
		// }
		// static bool CheckForEqualNumbers(List<int> ListOfNumbers)
		// {
		// 	List<int> workingList = new List<int>(ListOfNumbers);
		// 	bool foundEqualNumber = false;
		// 	int counter = 0;
		// 	for (int i = 0; i < workingList.Count - 1; i++)
		// 	{
		// 		if (workingList[i] == workingList[i + 1])
		// 		{
		// 			counter += 1;
		// 			if (counter > 1)
		// 				foundEqualNumber = true;

		// 			else
		// 			{
		// 				workingList.RemoveAt(i + 1);
		// 				i--;
		// 				continue;
		// 			}
		// 		}
		// 	}
		// 	return foundEqualNumber;
		// }
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
				if (CheckIfValid(numbers) || CanBecomeValidByRemovingOne(numbers))
					numOfSafeReports++;
			}
			return numOfSafeReports;

		}
		static bool CheckForIncreasingNumbers(List<int> ListOfNumbers)
		{
			// Check if each number is greater than the previous one
			for (int i = 1; i < ListOfNumbers.Count; i++)
			{
				// If the current number is not greater than the previous one OR the difference is greater than 3, return 0
				if (ListOfNumbers[i] < ListOfNumbers[i - 1] || Math.Abs(ListOfNumbers[i] - ListOfNumbers[i - 1]) > 3)
				{
					return false;
				}
			}
			// If the loop completes without returning 0, return 1 (list is increasing with the condition)
			return true;
		}
		static bool CheckForDecreasingNumbers(List<int> ListOfNumbers)
		{
			// Check if each number is greater than the previous one
			for (int i = 1; i < ListOfNumbers.Count; i++)
			{
				if ((ListOfNumbers[i] > ListOfNumbers[i - 1]) || (Math.Abs(ListOfNumbers[i] - ListOfNumbers[i - 1]) > 3))
					return false;
			}
			return true;
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
		static bool CheckIfValid(List<int> data)
		{
			if (CheckForEqualNumbers(data))
				return false;
			else if (CheckForIncreasingNumbers(data) || CheckForDecreasingNumbers(data))
				return true;
			else
				return false;
		}
		static bool CanBecomeValidByRemovingOne(List<int> report)
		{
			for (int i = 0; i < report.Count; i++)
			{
				var modifiedReport = report.Where((_, index) => index != i).ToList();
				if (CheckIfValid(modifiedReport))
					return true;
			}
			return false;
		}
		protected int SolvePart1()
		{
			int safeReports = CountSafeReports(this.rawData);
			return safeReports;
		}
		protected int SolvePart2()
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
		public override string SolutionToPart2
		{
			get
			{
				logger.LogInformation("Solving Part 2");
				return SolvePart2().ToString();
			}
		}



	}
}
