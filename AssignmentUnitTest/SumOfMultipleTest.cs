using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentUnitTest
{
	[TestClass]
	public class SumOfMultipleTest
	{
		[TestMethod]
		public void SumOfMultipleTest_Scenario1( )
		{
			ulong ret = SumOfMultiple.Calc( 6, 3, 5 );
			Assert.IsTrue( 8 == ret );
		}

		[TestMethod]
		public void SumOfMultipleTest_Scenario2( )
		{
			ulong ret = SumOfMultiple.Calc( 6, 1, 1 );

			// 1 + 2 + 3 + 4 + 5 = 15 // all this natural number multiple by 1
			Assert.IsTrue( 15 == ret );
		}
	}
}
