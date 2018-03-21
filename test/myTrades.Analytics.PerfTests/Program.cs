using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using MyTrades.Analytics.Tests;

namespace MyTrades.Analytics.PerfTests
{
	[MemoryDiagnoser]	
    public class Program
    {
        static void Main(string[] args)
        {
			var summary = BenchmarkRunner.Run<Program>();
		}

		[Benchmark]
		public void CalculateSmaPerf()
		{
			MovingAvgTest test = new MovingAvgTest();
			for (int i = 0; i < 10; i++)
			{
				test.TestSimpleMovingAvg();
			}
		}
    }
}
