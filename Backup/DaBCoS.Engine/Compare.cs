using System;
using System.Collections;

namespace DaBCoS.Engine
{
	/// <summary>
	/// Compare database objects
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	public class Compare
	{
		#region Instance Members

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		#endregion Constructor / Destructor

		#region Methods

		/// <summary>
		/// Compare tables
		/// </summary>
		public TableDifferenceCollection CompareTables(SqlServer databaseLeft, SqlServer databaseRight) 
		{
			ArrayList leftTableList, rightTableList;
			ArrayList leftColumnList, rightColumnList;
			TableDifferenceCollection tableDifferences = new TableDifferenceCollection();

			// Read first database tables
			//ShowInfoMessage(String.Format("Reading available tables on {0}..{1}...", databaseLeft.Connection.DataSource, databaseLeft.Connection.Database));
			leftTableList = databaseLeft.GetTables();

			// Read second database tables
			//ShowInfoMessage(String.Format("Reading available tables on {0}..{1}...", databaseRight.Connection.DataSource, databaseRight.Connection.Database));
			rightTableList = databaseRight.GetTables();

			// Fire event
			int numberObjects = leftTableList.Count;
			FireCompareSchemaStarted(Difference.DatabaseObjectType.Table, numberObjects);

			// Compare databases
			//ShowInfoMessage(String.Format("Found a total of {0} tables ({1} + {2})", leftTableList.Count + rightTableList.Count, leftTableList.Count, rightTableList.Count));
			//ShowInfoMessage("Comparing tables and columns...");		

			// Compare first database against the second
			for(int i=0; i<leftTableList.Count; i++) 
			{
				// Find existing and missing tables
				if (FindListItem(leftTableList[i].ToString(), rightTableList)==-1) 
				{
					// Right table missing
					tableDifferences.Add(new TableDifference(false, leftTableList[i].ToString(), Difference.DatabaseObjectType.Table, Difference.DifferenceOutcome.Missing));
				} 
				else 
				{
					bool fieldDifferenceFound = false;

					// Add a default table difference item
					int addedIndex = tableDifferences.Add(new TableDifference(false, leftTableList[i].ToString(), Difference.DatabaseObjectType.Table, Difference.DifferenceOutcome.Unknown));

					// Load columns
					leftColumnList = databaseLeft.GetColumns(leftTableList[i].ToString());
					rightColumnList = databaseRight.GetColumns(rightTableList[rightTableList.IndexOf(leftTableList[i])].ToString());

					// Check for different columns from left-table
					for (int j=0; j<leftColumnList.Count; j++)
					{
						// Check if the left-table column is in the right-table
						if (FindListItem(leftColumnList[j].ToString(), rightColumnList)==-1)
						{
							// Right field missing
							tableDifferences[addedIndex].FieldDifferences.Add(new Difference(false, leftColumnList[j].ToString(), Difference.DatabaseObjectType.Field, Difference.DifferenceOutcome.Missing));
							fieldDifferenceFound=true;
						}
					}

					// Check for different columns from right-table
					for (int j=0; j<rightColumnList.Count; j++)
					{
						// Check if the left-table column is in the right-table
						if (FindListItem(rightColumnList[j].ToString(), leftColumnList)==-1)
						{
							// Right field missing
							tableDifferences[addedIndex].FieldDifferences.Add(new Difference(false, rightColumnList[j].ToString(), Difference.DatabaseObjectType.Field, Difference.DifferenceOutcome.Missing));
							fieldDifferenceFound=true;
						}
					}

					// Check if we found any column differences
					if (!fieldDifferenceFound)
					{
						tableDifferences[addedIndex].Outcome = Difference.DifferenceOutcome.Same;
					}
					else
					{
						tableDifferences[addedIndex].Outcome = Difference.DifferenceOutcome.Different;
					}
				}
			}

			// Find tables in second database not yet scanned
			for(int i=0; i<rightTableList.Count; i++) 
			{
				if ((FindListItem(rightTableList[i].ToString(), leftTableList))==-1) 
				{
					// Left table missing
					tableDifferences.Add(new TableDifference(true, rightTableList[i].ToString(), Difference.DatabaseObjectType.Table, Difference.DifferenceOutcome.Missing));
				}
			}		

			// Sort by table name
			tableDifferences = tableDifferences.Sort("Name", SortDirection.Ascending);

			FireCompareSchemaFinished(Difference.DatabaseObjectType.Table);

			return tableDifferences;
		}

		/// <summary>
		/// Compare stored procedures
		/// </summary>
		public DifferenceCollection CompareSchemaObjects(SqlServer databaseLeft, SqlServer databaseRight, Difference.DatabaseObjectType schemaObjectType) 
		{
			ArrayList leftSchemaList, rightSchemaList;
			DifferenceCollection schemaDifferences = new DifferenceCollection();
			int addedIndex;

			leftSchemaList = databaseLeft.GetObjectList(schemaObjectType);
			rightSchemaList = databaseRight.GetObjectList(schemaObjectType);

			// Fire event
			int numberObjects = leftSchemaList.Count;
			FireCompareSchemaStarted(schemaObjectType, numberObjects);

			// Compare databases
			//ShowInfoMessage(String.Format("Found a total of {0} tables ({1} + {2})", leftSchemaList.Count + rightSchemaList.Count, leftSchemaList.Count, rightSchemaList.Count));
			//ShowInfoMessage("Comparing tables and columns...");		

			// Compare first database against the second
			for(int i=0; i<leftSchemaList.Count; i++) 
			{
				// Find existing and missing stored procs
				int schemaIndex = FindListItem(leftSchemaList[i].ToString(), rightSchemaList);
				if (schemaIndex==-1) 
				{
					// Right proc missing
					addedIndex = schemaDifferences.Add(new Difference(false, leftSchemaList[i].ToString(), schemaObjectType, Difference.DifferenceOutcome.Missing));

					// Load the schema for the stored procs
					string leftSchema = databaseLeft.GetObjectDefinition(leftSchemaList[i].ToString());
					string rightSchema = "";

					// Check for schema differences (we know there will be lots!)
					DifferenceEngine.TextMemory leftText = new DifferenceEngine.TextMemory(leftSchema);
					schemaDifferences[addedIndex].LeftText = leftText;
					DifferenceEngine.TextMemory rightText = new DifferenceEngine.TextMemory(rightSchema);
					schemaDifferences[addedIndex].RightText = rightText;

					DifferenceEngine.DiffEngine diffEngine = new DifferenceEngine.DiffEngine();
					double timeTaken = diffEngine.ProcessDiff(leftText, rightText, DifferenceEngine.DiffEngineLevel.SlowPerfect);
					DifferenceEngine.DiffResultSpanCollection textDifferenceList = diffEngine.DiffReport();

					schemaDifferences[addedIndex].DifferenceResults = textDifferenceList;
				} 
				else 
				{
					bool schemaDifferenceFound = false;

					// Add a default difference item
					addedIndex = schemaDifferences.Add(new Difference(false, leftSchemaList[i].ToString(), schemaObjectType, Difference.DifferenceOutcome.Unknown));

					// Load the schema text
					string leftSchema = databaseLeft.GetObjectDefinition(leftSchemaList[i].ToString());
					string rightSchema = databaseRight.GetObjectDefinition(rightSchemaList[schemaIndex].ToString());

					// Check for schema differences
					DifferenceEngine.TextMemory leftText = new DifferenceEngine.TextMemory(leftSchema);
					schemaDifferences[addedIndex].LeftText = leftText;
					DifferenceEngine.TextMemory rightText = new DifferenceEngine.TextMemory(rightSchema);
					schemaDifferences[addedIndex].RightText = rightText;

					DifferenceEngine.DiffEngine diffEngine = new DifferenceEngine.DiffEngine();
					double timeTaken = diffEngine.ProcessDiff(leftText, rightText, DifferenceEngine.DiffEngineLevel.SlowPerfect);
					DifferenceEngine.DiffResultSpanCollection textDifferenceList = diffEngine.DiffReport();

					// Check if we found any text differences
					foreach(DifferenceEngine.DiffResultSpan diffResultSpan in textDifferenceList)
					{
						if (diffResultSpan.Status!=DifferenceEngine.DiffResultSpanStatus.NoChange)
						{
							schemaDifferenceFound = true;
						}
					}
					schemaDifferences[addedIndex].DifferenceResults = textDifferenceList;
					if (schemaDifferenceFound)
					{
						schemaDifferences[addedIndex].Outcome = Difference.DifferenceOutcome.Different;
					}
					else
					{
						schemaDifferences[addedIndex].Outcome = Difference.DifferenceOutcome.Same;
					}
				}
			}

			// Find objects in second database not yet scanned
			for(int i=0; i<rightSchemaList.Count; i++) 
			{
				if ((FindListItem(rightSchemaList[i].ToString(), leftSchemaList))==-1) 
				{
					// Left object missing
					addedIndex = schemaDifferences.Add(new Difference(true, rightSchemaList[i].ToString(), schemaObjectType, Difference.DifferenceOutcome.Missing));

					// Load the schema for the stored procs
					string leftSchema = "";
					string rightSchema = databaseRight.GetObjectDefinition(rightSchemaList[i].ToString());

					// Check for schema differences (we know there will be lots!)
					DifferenceEngine.TextMemory leftText = new DifferenceEngine.TextMemory(leftSchema);
					schemaDifferences[addedIndex].LeftText = leftText;
					DifferenceEngine.TextMemory rightText = new DifferenceEngine.TextMemory(rightSchema);
					schemaDifferences[addedIndex].RightText = rightText;

					DifferenceEngine.DiffEngine diffEngine = new DifferenceEngine.DiffEngine();
					double timeTaken = diffEngine.ProcessDiff(leftText, rightText, DifferenceEngine.DiffEngineLevel.SlowPerfect);
					DifferenceEngine.DiffResultSpanCollection textDifferenceList = diffEngine.DiffReport();

					schemaDifferences[addedIndex].DifferenceResults = textDifferenceList;

				}
			}		

			// Sort by name
			schemaDifferences = schemaDifferences.Sort("Name", SortDirection.Ascending);

			FireCompareSchemaFinished(schemaObjectType);

			return schemaDifferences;
		}

		/// <summary>
		/// Compare two ArrayList to check if they contain the same values
		/// and thus are equivalent
		/// </summary>
		/// <param name="alFirst">First ArrayList to compare</param>
		/// <param name="alSecond">Second ArrayList to compare</param>
		/// <returns>true or false</returns>
		static internal bool ListAreEqual(ArrayList alFirst, ArrayList alSecond) 
		{
			if (alFirst.Count != alSecond.Count) return false;

			bool bResult = true;
			for(int i=0; i<alFirst.Count; i++) 
			{
				bResult &= (alFirst[i].ToString() == alSecond[i].ToString());
				if (!bResult)
				{
					return false;
				}
			}

			return bResult;
		}

		/// <summary>
		/// Look for a matching item in another array list
		/// </summary>
		/// <param name="alFirst">First ArrayList to compare</param>
		/// <param name="alSecond">Second ArrayList to compare</param>
		/// <returns>true or false</returns>
		static internal int FindListItem(string textToFind, ArrayList arrayList) 
		{
			// Loop through the array list items
			for(int i=0; i<arrayList.Count; i++) 
			{
				if (arrayList[i].ToString() == textToFind)
				{
					return i;
				}
			}

			return -1;
		}

		#endregion Methods

		#region Properties

		#endregion Properties

		#region Event Handlers

		#endregion Event Handlers

		#region Events

		public delegate void CompareSchemaStartedDelegate(object sender, CompareSchemaEventArgs e);

		public event CompareSchemaStartedDelegate CompareSchemaStarted;

		protected virtual void FireCompareSchemaStarted(Difference.DatabaseObjectType databaseObjectType, int numberObjects)
		{
			if (CompareSchemaStarted!=null)
			{
				CompareSchemaStarted(this, new CompareSchemaEventArgs(databaseObjectType, numberObjects));
			}
		}

		public delegate void CompareSchemaFinishedDelegate(object sender, Difference.DatabaseObjectType databaseObjectType);

		public event CompareSchemaFinishedDelegate CompareSchemaFinished;

		private void FireCompareSchemaFinished(Difference.DatabaseObjectType databaseObjectType)
		{
			if (CompareSchemaFinished!=null)
			{
				CompareSchemaFinished(this, databaseObjectType);
			}
		}

		#endregion Events

		#region Internal Classes

		#endregion Internal Classes

	}

	public class CompareSchemaEventArgs
	{
		#region Instance Variables

		private Difference.DatabaseObjectType _databaseObjectType;
		private int _numObjects;

		#endregion

		#region Constructor / Destructor

		public CompareSchemaEventArgs(Difference.DatabaseObjectType databaseObjecType, int numberOfObjects)
		{
			_databaseObjectType = databaseObjecType;
			_numObjects = numberOfObjects;
		}

		#endregion Constructor / Destructor

		#region Properties

		public Difference.DatabaseObjectType DatabaseObjectType
		{
			get
			{
				return _databaseObjectType;
			}
			set
			{
				_databaseObjectType = value;
			}
		}

		public int NumberOfObjects
		{
			get
			{
				return _numObjects;
			}
			set
			{
				_numObjects = value;
			}
		}

		#endregion Properties

	}
}
