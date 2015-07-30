using System;

namespace DaBCoS.Engine
{
	/// <summary>
	/// Summary description for TextDifference.
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	public class TextDifference:Difference
	{
		#region Instance Members

		private int _lineNumber;

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TextDifference()
	{
		//
		// TODO: Add constructor logic here
		//
	}

		#endregion Constructor / Destructor

		#region Methods

		#endregion Methods

		#region Properties

		public int LineNumber
		{
			get
			{
				return _lineNumber;
			}
			set
			{
				_lineNumber = value;
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
