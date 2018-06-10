using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentUnitTest
{
	[TestClass]
	public class SequenceAnalysisTest
	{
		[TestMethod]
		public void SequenceAnalysisTest_ReversAll_Scenario( )
		{
			string input = "GFEDCBA";
			string ret = SequenceAnalysis.FindAndOrderUpperCase( input );

			Assert.IsTrue( ret == "ABCDEFG" );
		}

		[TestMethod]
		public void SequenceAnalysisTest_SkipLowerCase_Scenario( )
		{
			string input = "ZyxwvA";
			string ret = SequenceAnalysis.FindAndOrderUpperCase( input );

			Assert.IsTrue( ret == "AZ" );
		}

		[TestMethod]
		public void SequenceAnalysisTest_AllLowerCase_Scenario( )
		{
			string input = "zyxwva";
			string ret = SequenceAnalysis.FindAndOrderUpperCase( input );

			Assert.IsTrue( ret == string.Empty );
		}

		[TestMethod]
		public void SequenceAnalysisTest_SkipNonLetterValue_Scenario( )
		{
			string input = "G*F1E$D-C(B!A";
			string ret = SequenceAnalysis.FindAndOrderUpperCase( input );

			Assert.IsTrue( ret == "ABCDEFG" );
		}

		[TestMethod]
		public void SequenceAnalysisTest_NoModifyNeed_Scenario( )
		{
			string input = "ABCDEFG";
			string ret = SequenceAnalysis.FindAndOrderUpperCase( input );

			Assert.IsTrue( ret == "ABCDEFG" );
		}
	}
}
