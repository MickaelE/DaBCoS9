using System;
using System.Xml;
using System.Xml.Serialization;

namespace DaBCoS.Engine
{
	/// <summary>
	/// Summary description for TableDifference.
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	public class TableDifference : Difference
	{
		#region Instance Members

		private DifferenceCollection _fieldDifferenceCol = new DifferenceCollection();

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		public TableDifference():base(){}

		public TableDifference(bool isLeftDifferent, string name, DatabaseObjectType objectType, DifferenceOutcome outcome):base(isLeftDifferent, name, objectType, outcome)
		{
		}

		#endregion Constructor / Destructor

		#region Methods

		#endregion Methods

		#region Properties

		public DifferenceCollection FieldDifferences
		{
			get
			{
				return _fieldDifferenceCol;
			}
			set
			{
				_fieldDifferenceCol = value;
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
