using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DaBCoS.Engine
{
	/// <summary>
	/// Summary description for DifferenceReport.
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	[XmlRootAttribute("differences")]
	public class DifferenceSerializer
	{
		#region Instance Members

		TableDifferenceCollection _tableDiffCollection = new TableDifferenceCollection();
		DifferenceCollection _viewDiffCollection = new DifferenceCollection();
		DifferenceCollection _storedProcDiffCollection = new DifferenceCollection();
		DifferenceCollection _functionDiffCollection = new DifferenceCollection();

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DifferenceSerializer()
		{
		}

		public DifferenceSerializer(TableDifferenceCollection tableDiffCollection, DifferenceCollection viewDiffCollection, DifferenceCollection storedProcDiffCollection, DifferenceCollection functionDiffCollection)
		{
			_tableDiffCollection = tableDiffCollection;
			_viewDiffCollection = viewDiffCollection;
			_storedProcDiffCollection = storedProcDiffCollection;
			_functionDiffCollection = functionDiffCollection;
		}

		#endregion Constructor / Destructor

		#region Methods

		/// <summary>
		/// Serialize the class and save to file
		/// </summary>
		/// <param name="fileName"></param>
		public void Save(string fileName)
		{
			try
			{
				// Creates an instance of the XmlSerializer class;
				// specifies the type of object to serialize.
				XmlSerializer serializer = new XmlSerializer(typeof(DifferenceSerializer));

				// Create an empty namespace
				XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(); 
				namespaces.Add(string.Empty, string.Empty); 

				TextWriter writer = new StreamWriter(fileName, false);
				XmlTextWriter xmlWriter = new XmlTextWriter(writer);
				xmlWriter.Formatting = Formatting.Indented; 
				xmlWriter.Indentation = 4; 
				xmlWriter.Namespaces = false; 
			
				// Serializes the object, and closes the TextWriter.
				serializer.Serialize(xmlWriter, this, namespaces);
				xmlWriter.Close();
				writer.Close();
				writer = null;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public static DifferenceSerializer Load(string fileName)
		{
			XmlSerializer xs = new XmlSerializer(typeof(DifferenceSerializer));
			StreamReader xmlStreamReader = new StreamReader(fileName);
			XmlTextReader xmlTextReader = new XmlTextReader(xmlStreamReader);

			DifferenceSerializer deserialized = (DifferenceSerializer)xs.Deserialize(xmlTextReader);
			xmlTextReader.Close();

			return deserialized;
		}

		#endregion Methods

		#region Properties

		[XmlElement("view")]
		public DifferenceCollection ViewDifferences
		{
			get
			{
				return _viewDiffCollection;
			}
			set
			{
				_viewDiffCollection = value;
			}
		}

		[XmlElement("table")]
		public TableDifferenceCollection TableDifferences
		{
			get
			{
				return _tableDiffCollection;
			}
			set
			{
				_tableDiffCollection = value;
			}
		}

		[XmlElement("function")]
		public DifferenceCollection FunctionDifferences
		{
			get
			{
				return _functionDiffCollection;
			}
			set
			{
				_functionDiffCollection = value;
			}
		}

		[XmlElement("storedproc")]
		public DifferenceCollection StoredProcDifferences
		{
			get
			{
				return _storedProcDiffCollection;
			}
			set
			{
				_storedProcDiffCollection = value;
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
