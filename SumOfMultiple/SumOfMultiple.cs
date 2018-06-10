using System.Threading.Tasks;
using System;


public class SumOfMultiple
{
	public static ulong Calc( uint limit, uint param1, uint param2 )
	{
		if ( limit < param1 || limit < param2 )
		{
			throw new ArgumentException( "limit must be greater then param1 & param2" );
		}
		if ( 0 == param1 || 0 == param2 )
		{
			throw new ArgumentException( "0 is not a valid value" );
		}

		ulong ret = 0;

		// open 2 task 1 for each param.

		// this task will add only natural number that multiple with param1 & will skip the result that also multiple
		// with param 2 - avoid double insert of same number
		Task<ulong> task1 = Task.Run<ulong>( ( ) => GetSumOfMultiple( limit, param1, param2 ) );

		//add all numbers until limit multiple with param1 
		Task<ulong> task2 = Task.Run<ulong>( ( ) => GetSumOfMultiple( limit, param2 ) );

		// wait for result and return result sum
		ret = task1.Result + task2.Result;

		return ret;
	}

	private static ulong GetSumOfMultiple( uint limit, uint multipleOf, uint exclude )
	{
		uint ret = 0;

		// increment by size of 'multipleOf' until less then limit
		for ( uint i = multipleOf; i < limit; i += multipleOf )
		{
			// if current number also divided by the exclude number - don't add it
			if ( 0 != i % exclude )
			{
				ret += i;
			}
		}

		return ret;	
	}

	private static ulong GetSumOfMultiple( uint limit, uint multipleOf )
	{
		uint ret = 0;

		// increment by size of 'multipleOf' until less then limit
		for ( uint i = multipleOf; i < limit; i += multipleOf )
		{
			ret += i;
		}

		return ret;
	}
}