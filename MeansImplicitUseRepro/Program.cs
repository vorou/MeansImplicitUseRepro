using System;
using System.Linq.Expressions;
using SimpleContainer.Infection;
// ReSharper disable InconsistentNaming

namespace MeansImplicitUseRepro
{
	internal static class Program
	{
		public static void Main()
		{
			var a = new Bombaclat(null);
			a.Do();
		}
	}

	public class Bombaclat
	{
		private IArgumentProvider notUsedAtAll;

		[Inject]
		private IArgumentProvider assignedImplicitlyButNotUsed;

		private IArgumentProvider assignedExplicitlyButNotUsed;
		
		[Inject]
		private IArgumentProvider assignedAndUsed;
		
		public Bombaclat(IArgumentProvider assignedExplicitlyButNotUsed)
		{
			this.assignedExplicitlyButNotUsed = assignedExplicitlyButNotUsed;
		} 
		
		public void Do()
		{
			Console.Out.WriteLine(assignedAndUsed);
		}
	}
}