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
	public class DatabaseDifferences
	{
		#region Instance Members

		TableDifferenceCollection _tableDiffCollection = new TableDifferenceCollection();
		DifferenceCollection _constraintDiffCollection = new DifferenceCollection();
        DifferenceCollection _userDiffCollection = new DifferenceCollection();
		DifferenceCollection _functionDiffCollection = new DifferenceCollection();
		DifferenceCollection _storedProcDiffCollection = new DifferenceCollection();
		DifferenceCollection _triggerDiffCollection = new DifferenceCollection();
		DifferenceCollection _viewDiffCollection = new DifferenceCollection();

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DatabaseDifferences()
		{
		}

		public DatabaseDifferences(TableDifferenceCollection tableDiffCollection, 
									DifferenceCollection constraintDiffCollection, 
									DifferenceCollection viewDiffCollection, 
									DifferenceCollection storedProcDiffCollection, 
									DifferenceCollection functionDiffCollection, 
									DifferenceCollection triggerDiffCollection)
		{
			_constraintDiffCollection = constraintDiffCollection;
			_functionDiffCollection = functionDiffCollection;
			_storedProcDiffCollection = storedProcDiffCollection;
			_tableDiffCollection = tableDiffCollection;
			_triggerDiffCollection = triggerDiffCollection;
			_viewDiffCollection = viewDiffCollection;
		}

		#endregion Constructor / Destructor

		#region Methods

		/// <summary>
		/// Serialize the class and save to file
		/// </summary>
		/// <param name="fileName"></param>
		public void Save(string fileName)
		{
			TextWriter writer = new StreamWriter(fileName, false);
			XmlTextWriter xmlWriter = new XmlTextWriter(writer);
			xmlWriter.Formatting = Formatting.Indented; 
			xmlWriter.Indentation = 4; 
			xmlWriter.Namespaces = false; 

			// Write the xml
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("databasedifferences");

			// Output the schema sections
			OutputSchemaXml(xmlWriter, (DifferenceCollection)this.TableDifferences);
			OutputSchemaXml(xmlWriter, this.FunctionDifferences);
			OutputSchemaXml(xmlWriter, this.StoredProcDifferences);
			OutputSchemaXml(xmlWriter, this.ViewDifferences);
			OutputSchemaXml(xmlWriter, this.TriggerDifferences);

			xmlWriter.WriteEndElement();	//databasedifferences

			// Serializes the object, and closes the TextWriter.
			xmlWriter.Close();
			writer.Close();
			writer = null;
		}

		public void OutputSchemaXml(XmlWriter xmlWriter, DifferenceCollection diffCollection)
		{
			if (diffCollection!=null)
			{
				// Output the schema differences
				foreach(Difference schemaDiff in diffCollection)
				{
					xmlWriter.WriteStartElement(schemaDiff.ObjectType.ToString().ToLower());
					xmlWriter.WriteStartAttribute("name", string.Empty);
					xmlWriter.WriteString(schemaDiff.Name);
					xmlWriter.WriteEndAttribute();	//name
					xmlWriter.WriteStartAttribute("objecttype", string.Empty);
					xmlWriter.WriteString(schemaDiff.ObjectType.ToString());
					xmlWriter.WriteEndAttribute();	//objecttype
					xmlWriter.WriteStartAttribute("outcome", string.Empty);
					xmlWriter.WriteString(schemaDiff.Outcome.ToString());
					xmlWriter.WriteEndAttribute();	//outcome
					xmlWriter.WriteStartAttribute("isleftdifferent", string.Empty);
					xmlWriter.WriteString(schemaDiff.IsLeftDifferent.ToString());
					xmlWriter.WriteEndAttribute();	//isleftdifferent
					xmlWriter.WriteStartAttribute("change", string.Empty);
					xmlWriter.WriteString(schemaDiff.Change.ToString());
					xmlWriter.WriteEndAttribute();	//change
					xmlWriter.WriteEndElement();	//table
				}
			}
		}

		public static DatabaseDifferences Load(string fileName)
		{
			XmlSerializer xs = new XmlSerializer(typeof(DatabaseDifferences));
			StreamReader xmlStreamReader = new StreamReader(fileName);
			XmlTextReader xmlTextReader = new XmlTextReader(xmlStreamReader);

			DatabaseDifferences deserialized = (DatabaseDifferences)xs.Deserialize(xmlTextReader);
			xmlTextReader.Close();

			return deserialized;
		}

		#endregion Methods

		#region Properties

        public DifferenceCollection UserDifferences
        {
            get
            {
                return _userDiffCollection;
            }
            set
            {
                _userDiffCollection = value;
            }
        }
		public DifferenceCollection ConstraintDifferences
		{
			get
			{
				return _constraintDiffCollection;
			}
			set
			{
				_constraintDiffCollection = value;
			}
		}

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

		public DifferenceCollection TriggerDifferences
		{
			get
			{
				return _triggerDiffCollection;
			}
			set
			{
				_triggerDiffCollection = value;
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
