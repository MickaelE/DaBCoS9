using System;
using System.IO;

namespace DaBCoS.Engine
{
	/// <summary>
	/// Stores difference information between two compared objects
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	public class Difference
	{
		#region Instance Members

		private bool _isLeftDifferent;
		private string _name;
		private DatabaseObjectType _objectType;
		private DifferenceOutcome _differenceOutcome;
		private ChangeRequired _changeRequired;
		private int _diffTimeTaken;
		private DifferenceEngine.DiffResultSpanCollection _diffResultSpanCollection;
		private DifferenceEngine.TextMemory _leftText;
		private DifferenceEngine.TextMemory _rightText;

		#endregion Instance Members

		#region Enums

		public enum DatabaseObjectType
		{
			Table = 0,
			StoredProcedure,
			View,
			Function,
			Field,
			Trigger,
			Constraint
		}

		public enum DifferenceOutcome
		{
			Unknown = 0,
			Same,
			Missing,
			Different
		}

		public enum ChangeRequired
		{
			None = 0,
			Insert,
			Merge
		}

		#endregion Enums

		#region Constructor / Destructor

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Difference()	{}

		public Difference(bool isLeftDifferent, string name, DatabaseObjectType objectType, DifferenceOutcome outcome)
		{
			this.IsLeftDifferent = isLeftDifferent;
			this.Name = name;
			this.ObjectType = objectType;
			this.Outcome = outcome;
			this.Change = ChangeRequired.None;
		}

		public Difference(bool isLeftDifferent, string name, DatabaseObjectType objectType, DifferenceOutcome outcome, ChangeRequired change)
		{
			this.IsLeftDifferent = isLeftDifferent;
			this.Name = name;
			this.ObjectType = objectType;
			this.Outcome = outcome;
			this.Change = change;
		}

		#endregion Constructor / Destructor

		#region Methods

		#endregion Methods

		#region Properties

		public bool IsLeftDifferent
		{
			get
			{
				return _isLeftDifferent;
			}
			set
			{
				_isLeftDifferent = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public DatabaseObjectType ObjectType
		{
			get
			{
				return _objectType;
			}
			set
			{
				_objectType = value;
			}
		}

		public DifferenceOutcome Outcome
		{
			get
			{
				return _differenceOutcome;
			}
			set
			{
				_differenceOutcome = value;
			}
		}

		public ChangeRequired Change
		{
			get
			{
				return _changeRequired;
			}
			set
			{
				_changeRequired = value;
			}
		}

		public DifferenceEngine.DiffResultSpanCollection DifferenceResults
		{
			get
			{
				return _diffResultSpanCollection;
			}
			set
			{
				_diffResultSpanCollection = value;
			}
		}

		public DifferenceEngine.TextMemory LeftText
		{
			get
			{
				return _leftText;
			}
			set
			{
				_leftText = value;
			}
		}

		public DifferenceEngine.TextMemory RightText
		{
			get
			{
				return _rightText;
			}
			set
			{
				_rightText = value;
			}
		}

		public int TimeTaken
		{
			get
			{
				return _diffTimeTaken;
			}
			set
			{
				_diffTimeTaken = value;
			}
		}

		#endregion Properties

		#region Event Handlers

		#endregion Event Handlers

		#region Events

		#endregion Events

		#region Internal Classes

		#endregion Internal Classes

	}
}
