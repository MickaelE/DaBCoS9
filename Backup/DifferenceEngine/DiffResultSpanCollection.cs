
#region Using

using System;
using System.Collections;
//UPDATE
using T = DifferenceEngine.DiffResultSpan;

#endregion

namespace DifferenceEngine
{
	/// <summary>
	/// Strongly typed collection for DiffResultSpan Entity
	/// </summary>
	public class DiffResultSpanCollection : System.Collections.CollectionBase
	{
		
		#region Constructor(s)

		public DiffResultSpanCollection() : base(){}

		public DiffResultSpanCollection(ArrayList array)
		{
			foreach (T o in array)
			{
				this.Add(o);
			}
		}
    
		#endregion

		#region Properties

		public T this [int index]
		{
			get {return (T)(this.List[index]);}
			set {this.List[index] = value;}
		}

		#endregion

		#region Public Methods

		//-------------------------------------------------------------------------------------------
		/// <summary>
		/// Adds an item to the collection
		/// </summary>
		/// <param name="value">The item to add</param>
		/// <returns>The position into which the new element was inserted</returns>
		public int Add(T value)
		{
			return this.List.Add(value);
		}
		

		//-------------------------------------------------------------------------------------------
		/// <summary>
		/// Determines whether the collection contains a specific item
		/// </summary>
		/// <param name="value">The item to be located</param>
		/// <returns>True if found</returns>
		public bool Contains(T value)
		{
			return this.List.Contains(value);
		}


		//-------------------------------------------------------------------------------------------
		/// <summary>
		/// Determines the index of a given item
		/// </summary>
		/// <param name="value">The item to be located</param>
		/// <returns></returns>
		public int IndexOf(T value)
		{
			return this.List.IndexOf(value);
		}


		//-------------------------------------------------------------------------------------------
		/// <summary>
		/// Removes the first occurance of the specified item in the collection
		/// </summary>
		/// <param name="value">The item to be removed</param>
		public void Remove(T value)
		{
			this.List.Remove(value);
		}


		//-------------------------------------------------------------------------------------------
		//UPDATE
		public new DifferenceCollectionEnumerator GetEnumerator()
		{
			return new DifferenceCollectionEnumerator(this);
		}


		//-------------------------------------------------------------------------------------------
		/// <summary>
		/// Inserts an item into the specified position in the collection
		/// </summary>
		/// <param name="index">The zero-based index at which value should be inserted</param>
		/// <param name="value"></param>
		public void Insert(int index, T value)
		{
			this.List.Insert(index, value);
		}


		//UPDATE
		//-------------------------------------------------------------------------------------------
		/// <summary>
		/// Sorts the collection based on a given property and direction
		/// </summary>
		/// <param name="sortParameter"></param>
		/// <param name="sortDirection"></param>
		/// <returns></returns>
		public DiffResultSpanCollection Sort(string sortParameter, SortDirection sortDirection)
		{
			ArrayList sortList = (ArrayList)this.InnerList.Clone();
			CollectionSorter cs = new CollectionSorter(sortParameter, sortDirection);
			sortList.Sort(cs);

			//UPDATE
			return new DiffResultSpanCollection(sortList);
		}

		#endregion
		
		#region Internal Classes

		public class DifferenceCollectionEnumerator : System.Collections.IEnumerator
		{
	
			#region Constructor(s)

			//UPDATE
			internal DifferenceCollectionEnumerator (DiffResultSpanCollection collection)
			{
				_index = -1;
				_collection = collection;
			}

			#endregion

			#region Class Variables

			private int _index;
			private T _currentElement;

			//UPDATE
			private DiffResultSpanCollection _collection;

			#endregion

			#region Properties

			/// <summary>
			/// The current entry in the enumeration
			/// </summary>
			public object Current
			{
				get
				{
					if ((_index == -1) || (_index >= _collection.Count))
					{
						_index++;
						_currentElement = _collection[_index];

						throw new IndexOutOfRangeException("Enumerator not started");
					}
					else
					{
						return _currentElement;
					}
				}
			}

			#endregion

			#region Public Methods
			
			//-------------------------------------------------------------------------------------------
			/// <summary>
			/// Moves to the next entry in the enumeration
			/// </summary>
			/// <returns>True on success</returns>
			public bool MoveNext()
			{
				if (_index < (_collection.Count - 1))
				{
					_index++;
					_currentElement = _collection[_index];
					return true;
				}
				_index = _collection.Count;
				return false;
			}

			//-------------------------------------------------------------------------------------------
			/// <summary>
			/// Resets the enumeration
			/// </summary>
			public void Reset()
			{
				_index--;
				_currentElement = null;
			}

			#endregion

		}

		#endregion

	}
}
