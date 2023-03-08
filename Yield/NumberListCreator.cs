using System;
namespace Yield
{
	public static class NumberListCreator
	{
		public static IEnumerable<int> Create100NumberList() => Enumerable.Range(0, 100);
		public static IEnumerable<int> Create1000NumberList() => Enumerable.Range(0, 1000);
    }
}

