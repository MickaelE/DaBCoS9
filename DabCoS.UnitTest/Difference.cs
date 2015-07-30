using System;

using NUnit.Framework;

using DaBCoS.Engine;

namespace DabCoS.UnitTest
{
	/// <summary>
	/// Summary description for BaseDifferent.
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	[TestFixture]
	public class Difference
	{
		#region Instance Members

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Difference()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion Constructor / Destructor

		#region Unit Tests

		[Test]
		public void CreateObjectValid()
		{
			DaBCoS.Engine.Difference difference = CreateObject();
			Assert.IsNotNull(difference);
		}

		#endregion Unit Tests

		#region Methods

		private DaBCoS.Engine.Difference CreateObject()
		{
			return new DaBCoS.Engine.Difference();
		}

		#endregion Methods

		#region Properties

		#endregion Properties

		#region Event Handlers

		#endregion Event Handlers

		#region Events

		#endregion Events

		#region Internal Classes

		#endregion Internal Classes

	}
}
