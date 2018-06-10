using System;

namespace Runner
{
	class Program
	{
		static void Main( string[ ] args )
		{
			bool stop = false;
			while ( !stop )
			{
				Console.WriteLine( "Press 1 for SumOfMultiple." );
				Console.WriteLine( "Press 2 for SequenceAnalysis." );
				Console.WriteLine( "Press x for exit." );
				ConsoleKeyInfo info = Console.ReadKey( );

				switch( info.KeyChar )
				{
					case 'x':
						stop = true;
						break;
					case '1':
						RunSumOfMultipleScenario( );
						break;
					case '2':
						SequenceAnalysisScenario( );
						break;
					default:
						break;
				}
			}
#if false

			//Console.ReadKey( );
			////for ( int i = 0; i < 100000; i++ )
			////{
			////	long sum = SumOfMultiple.Calc( 100000, 5, 3 );
			////	Console.WriteLine( "res = " + sum.ToString( ) );
			////}

			//string s = SequenceAnalysis.FindAndOrderUpperCase( "ZZZZZZ This IS a STRING AAAAAA 5" );

			//Console.WriteLine( s );
			//Console.WriteLine( "------------------------" );
			//Console.ReadKey( );
#endif
		}

		private static void SequenceAnalysisScenario( )
		{
			Console.Clear( );
			Console.WriteLine( "Sequence of analysis will return sorted sequence of upper case letter from your input string" );
			Console.Write( "Type string: " );
			string input = Console.ReadLine( );
			string result = SequenceAnalysis.FindAndOrderUpperCase( input );
			Console.WriteLine( string.Format("Sequence analysis result = {0}\n", result ) );
		}

		private static void RunSumOfMultipleScenario( )
		{
			Console.Clear( );
			Console.WriteLine( "Sum of multiple will find the sum of all natural numbers that are multiple of 3 or 5 below the limit provide as input" );
			Console.Write( "Please provide limit: " );
			string input = Console.ReadLine( );
			try
			{
				uint limit = uint.Parse( input );
				ulong result = SumOfMultiple.Calc( limit, 3, 5 );
				Console.WriteLine( string.Format( "Sequence analysis result = {0}\n", result ) );
			}
			catch ( Exception e )
			{
				Console.WriteLine( e.Message + "\n" );
			}
		}
	}
}
