using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DifferenceEngine
{
	/// <summary>
	/// Summary description for TextMemory.
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	public class TextMemory : IDiffList
	{
		#region Instance Members

		private int _maxLineLength = 1024;
		private TextLineCollection _lines;
		private bool _trimWhiteSpace = true;
		private bool _removeOuterBlankLines = true;

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		public TextMemory(){}

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="text"></param>
		public TextMemory(string text)
		{
			_lines = new TextLineCollection();
			using (StringReader sr = new StringReader(text)) 
			{
				String line;
				// Read and display lines from the file until the end of 
				// the file is reached.
				while ((line = sr.ReadLine()) != null) 
				{
					if (line.Length > MaxLineLength)
					{
						throw new InvalidOperationException(
							string.Format("File contains a line greater than {0} characters.",
							MaxLineLength.ToString()));
					}
					if (TrimWhiteSpace)
					{
						line = line.Trim();
					}
					_lines.Add(new TextLine(line));
				}

				if (this.RemoveOuterBlankLines)
				{
					// Remove blank lines at start
					while (_lines.Count>0)
					{
						// Check if the first line is blank
						if (_lines[0].Line.Length==0)
						{
							_lines.RemoveAt(0);
						}
						else
						{
							break;
						}
					}
					// Remove blank lines at end
					while (_lines.Count>0)
					{
						// Check if the last line is blank
						if (_lines[_lines.Count-1].Line.Length==0)
						{
							_lines.RemoveAt(_lines.Count-1);
						}
						else
						{
							break;
						}
					}
				}
			}
		}

		#endregion Constructor / Destructor

		#region Methods

		#endregion Methods

		#region Properties

		[XmlIgnore]
		public int MaxLineLength
		{
			get
			{
				return _maxLineLength;
			}
			set
			{
				_maxLineLength = value;
			}
		}

		[XmlElement("lines")]
		public TextLineCollection Lines
		{
			get
			{
				return _lines;
			}
		}

		[XmlIgnore]
		public bool TrimWhiteSpace
		{
			get
			{
				return _trimWhiteSpace;
			}
			set
			{
				_trimWhiteSpace = value;
			}
		}

		/// <summary>
		/// Flag to remove starting and ending blank lines
		/// For example, if a file has 5 lines, with lines 2, 3, and 4 having
		/// data but lines 1 and 5 have no data, then lines 1 and 5 would
		/// be removed.
		/// </summary>
		[XmlIgnore]
		public bool RemoveOuterBlankLines
		{
			get
			{
				return _removeOuterBlankLines;
			}
			set
			{
				_removeOuterBlankLines = value;
			}
		}

		#endregion Properties

		#region Event Handlers

		#endregion Event Handlers

		#region Events

		#endregion Events

		#region Internal Classes

		#endregion Internal Classes

		#region IDiffList Members

		public int Count()
		{
			return _lines.Count;
		}

		public IComparable GetByIndex(int index)
		{
			return (TextLine)_lines[index];
		}

		#endregion

	}
}
