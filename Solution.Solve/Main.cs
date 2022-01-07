using System;
using System.Collections.Generic;
using System.Linq;


namespace Solution.Solve
{
	public class Main
	{
		public static string Mix(string s1, string s2)
		{
			if (s1.Equals(s2, StringComparison.Ordinal))
				return string.Empty;

			var s1Info = GetDifferenceFromStringInfo(CountLowercaseSymbols(s1), "1");
			var s2Info = GetDifferenceFromStringInfo(CountLowercaseSymbols(s2), "2");

			var results = MergeDifferences(s1Info, s2Info).Select(difference =>
				$"{difference.Identifier}:{new string(difference.Symbol, difference.Count)}");

			return string.Join("/", results);
		}


		private static IEnumerable<Difference> MergeDifferences(params IEnumerable<Difference>[] differences) =>
			differences
				.SelectMany(enumerable => enumerable)
				.Where(difference => difference.Count > 1)
				.GroupBy(difference => difference.Symbol,
					(_, enumerable) =>
					{
						var local = enumerable
									.OrderByDescending(difference => difference.Count)
									.ToArray();

						var maxCount = enumerable.First().Count;

						var taked = local.TakeWhile(difference => difference.Count == maxCount);

						var first = local.First();
						if (taked.Count() > 1)
							first.Identifier = Difference.EqualityIdentifier;

						return first;
					})
				.OrderByDescending(difference => difference.Count)
				.ThenBy(difference => difference.Identifier, StringComparer.Ordinal)
				.ThenBy(difference => difference.Symbol);


		private static IEnumerable<Difference> GetDifferenceFromStringInfo(Dictionary<char, int> info, string identifier) =>
			info.Select(arg => new Difference
			{
				Identifier = identifier,
				Symbol     = arg.Key,
				Count      = arg.Value
			});


		private static Dictionary<char, int> CountLowercaseSymbols(string input) =>
			input
				.Where(char.IsLower)
				.GroupBy(c => c)
				.Select(chars => new
				{
					Symbol = chars.Key,
					Count  = chars.Count()
				})
				.ToDictionary(arg => arg.Symbol, arg => arg.Count);


		private sealed class Difference
		{
			public static readonly string EqualityIdentifier = "=";

			public string? Identifier { get; set; }
			public char Symbol { get; set; }
			public int Count { get; set; }
		}
	}
}