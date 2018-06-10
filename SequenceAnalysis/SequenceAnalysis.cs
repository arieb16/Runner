using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

public class SequenceAnalysis
{
	public static string FindAndOrderUpperCase( string input )
	{
		string ret = string.Empty;

		// add to this thread safe collection the capital letter.
		ConcurrentBag<char> upperCaseCollection = new ConcurrentBag<char>( );

		// split the string to words - check each word in a task
		string[ ] inputItems = input.Split( );

		// add the task to this tasks collection and then wait the tasks to complete
		List<Task> taskList = new List<Task>( 0 );

		// loop the words
		foreach ( string item in inputItems )
		{
			// create task foreach word
			Task task = Task.Run( ( ) => FetchUpperCaseLetters( item, upperCaseCollection ) );

			// add the task to collection
			taskList.Add( task );
		}

		// wait the task to complete
		Task.WaitAll( taskList.ToArray() );

		// create unsorted string
		ret = new string( upperCaseCollection.ToArray( ) );

		// sort string
		var order  = ret.OrderBy( c => c );

		// create sort string
		ret = new string( order.ToArray( ) );

		return ret;
	}

	private static void FetchUpperCaseLetters( string item, ConcurrentBag<char> upperCaseCollection )
	{
		// loop each char in parallel
		Parallel.ForEach( item, delegate ( char ch )
		{
			// if letter & upper
			if ( char.IsLetter( ch ) && char.IsUpper( ch ) )
			{
				// add to the thread safe collection
				upperCaseCollection.Add( ch );
			}
		} );
	}
}