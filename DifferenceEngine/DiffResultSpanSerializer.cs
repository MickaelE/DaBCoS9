using System;
using System.Xml;
using System.Xml.Serialization;

namespace DifferenceEngine
{
	/// <summary>
	/// Summary description for DiffResultSpanSerializer.
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	public class DiffResultSpanSerializer
	{
		#region Instance Members

		DiffResultSpanCollection _diffResultSpanCollection;

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DiffResultSpanSerializer()
		{
		}

		public DiffResultSpanSerializer(DiffResultSpanCollection diffResultSpanCollection)
		{
			_diffResultSpanCollection = diffResultSpanCollection;
		}

		#endregion Constructor / Destructor

		#region Methods

		#endregion Methods

		#region Properties

		[XmlElement("results")]
		public DiffResultSpanCollection Results
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

		#endregion Properties

		#region Event Handlers

		#endregion Event Handlers

		#region Events

		#endregion Events

		#region Internal Classes

		#endregion Internal Classes

	}
}
