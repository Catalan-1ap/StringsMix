using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Solution.Benchmark
{
	internal class Program
	{
		private static void Main(string[] args) => BenchmarkRunner.Run<Benchy>();
	}


	[MemoryDiagnoser]
	public class Benchy { }
}