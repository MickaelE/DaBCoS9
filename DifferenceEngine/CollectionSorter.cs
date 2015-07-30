
#region Using

using System.Collections;
using System;

#endregion

namespace DifferenceEngine
{
	/// <summary>
	/// Helper class for sorting Custom Collections
	/// </summary>
	internal class CollectionSorter : IComparer
	{

		#region Constructor(s)

		public CollectionSorter(string sortBy, SortDirection sortDirection) 
		{ 
			this.sortBy = sortBy; 
			this.sortDirection = sortDirection; 
		} 

		#endregion 

		#region Class Variables

		protected string sortBy; 
		protected SortDirection sortDirection; 

		#endregion

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y) 
		{ 
			return Compare( x, y, sortBy); 
		} 

		#endregion

		#region Private Methods

		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="comparer"></param>
		/// <returns></returns>
		int Compare( object x, object y, string comparer) 
		{ 
			if ((x == null) && (y==null)) return 0; 
			if (x == null) return -1; 
			if (y == null) return 1; 
			if (comparer.IndexOf( ".") != -1) 
			{ 
				//split the string 
				string[] parts = comparer.Split( new char[]{ '.'} ); 
				return Compare(	x.GetType().GetProperty( parts[0]).GetValue(x, null), 
					y.GetType().GetProperty( parts[0]).GetValue(y, null), parts[1]); 
			} 
			else 
			{ 
				IComparable icx, icy; 
				icx = (IComparable)x.GetType().GetProperty(comparer).GetValue(x, null); 
				icy = (IComparable)y.GetType().GetProperty(comparer).GetValue(y, null); 

				if (x.GetType().GetProperty(comparer).PropertyType  == typeof(string)) 
				{ 
					icx = (IComparable) icx.ToString().ToUpper(); 
					icy = (IComparable) icy.ToString().ToUpper(); 
				} 
				if (this.sortDirection == SortDirection.Descending) 
				{
					return icy.CompareTo(icx); 
				}
				else 
				{
					return icx.CompareTo(icy); 
				}
			} 
		} 
		#endregion
	
	} 

	#region Enums

	//	public enum SortByType 
	//	{ 
	//		Method = 0, 
	//		Property = 1 
	//	} 

	public enum SortDirection 
	{ 
		Ascending = 0, 
		Descending = 1 
	} 

	#endregion
}

