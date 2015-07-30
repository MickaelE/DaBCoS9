using System;
using System.Xml;
using System.Xml.Serialization;

namespace DifferenceEngine
{
	/// <summary>
	/// TextLine class
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	public class TextLine : IComparable
	{
		#region Instance Members

		private string _line;
		private int _hash;

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		public TextLine(){}

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="str"></param>
		public TextLine(string str)
		{
			_line = str.Replace("\t","    ");
			_hash = str.GetHashCode();
		}

		#endregion Constructor / Destructor

		#region Methods

		#endregion Methods

		#region Properties

		[XmlElement("line")]
		public string Line
		{
			get
			{
				return _line;
			}
			set
			{
				_line = value;
			}
		}

		[XmlIgnore]
		public int Hash
		{
			get
			{
				return _hash;
			}
			set
			{
				_hash = value;
			}
		}

		#endregion Properties

		#region Event Handlers

		#endregion Event Handlers

		#region Events

		#endregion Events

		#region Internal Classes

		#endregion Internal Classes

		#region IComparable Members

		public int CompareTo(object obj)
		{
			return _hash.CompareTo(((TextLine)obj)._hash);
		}

		#endregion

	}
}
