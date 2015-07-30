using System;

namespace DaBCoS.Cmd
{
	/// <summary>
	/// Summary description for Controller.
	/// </summary>
	/// <history>
	/// 	<modification date=”” author=”” comment=”Created”/>
	/// </history>
	public class Controller
	{
		#region Instance Members

		#endregion Instance Members

		#region Enums

		#endregion Enums

		#region Constructor / Destructor

		#endregion Constructor / Destructor

		#region Methods

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			string fileName;
			string connect1;
			string connect2;
			bool includeConstraints = false;
			bool includeFunctions = false;
			bool includeProcs = false;
			bool includeTables = false;
			bool includeTriggers = false;
			bool includeViews = false;
			bool includeAll = true;

			// Check args passed
			if (args.Length<3)
			{
				System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
				Console.WriteLine("DaBCoS Command-Line v" + executingAssembly.GetName().Version);
				Console.WriteLine("Generates an xml database schema difference file");
				Console.WriteLine();
				Console.WriteLine("Usage: dabcos-cmd /connect1:<connection string> /connect2:<connection string> /out:<output file> [options]\n");
				Console.WriteLine();
				Console.WriteLine("/connect1\t\tFirst database connection string");
				Console.WriteLine("/connect2\t\tSecond database connection string");
				Console.WriteLine("/out\t\t\tOutput file name");
				Console.WriteLine("/includeconstraints\tInclude constraint comparisons (/ic)");
				Console.WriteLine("/includefunctions\tInclude function comparisons (/if)");
				Console.WriteLine("/includeprocs\t\tInclude stored procedure comparisons (/ip)");
				Console.WriteLine("/includetables\t\tInclude table comparisons (/it)");
				Console.WriteLine("/includetriggers\tInclude trigger comparisons (/ir)");
				Console.WriteLine("/includeviews\t\tInclude view comparisons (/iv)");
				Console.WriteLine();
				Console.WriteLine("Connection string examples:");
				Console.WriteLine("Trusted  - `Data Source=Aron1;Initial Catalog=pubs;Integrated Security=SSPI;`");
				Console.WriteLine("SQL Auth - `Data Source=Aron1;Initial Catalog=pubs;User Id=sa;Password=asdasd;`");
				return;
			}

			// Get the arguments
			ArgParser argParser = new ArgParser(args);
			connect1 = argParser["connect1"].Value;
			connect2 = argParser["connect2"].Value;
			fileName = argParser["out"].Value;

			// Validate the args
			if (connect1.Length==0)
			{
				Console.WriteLine("EXCEPTION: connect1 is invalid.");
				return;
			}
			if (connect2.Length==0)
			{
				Console.WriteLine("EXCEPTION: connect2 is invalid.");
				return;
			}
			if (fileName.Length==0)
			{
				Console.WriteLine("EXCEPTION: output filename is invalid.");
				return;
			}
			fileName = System.IO.Path.GetFullPath(argParser["out"].Value);

			// Check if user wants to choose what to compare 
			if (argParser.Exists("includeconstraints") || argParser.Exists("ic"))
			{
				includeAll = false;
				includeConstraints = true;
			}
			if (argParser.Exists("includefunctions") || argParser.Exists("if"))
			{
				includeAll = false;
				includeFunctions = true;
			}
			if (argParser.Exists("includeprocs") || argParser.Exists("ip"))
			{
				includeAll = false;
				includeProcs = true;
			}
			if (argParser.Exists("includetables") || argParser.Exists("it"))
			{
				includeAll = false;
				includeTables = true;
			}
			if (argParser.Exists("includetriggers") || argParser.Exists("ir"))
			{
				includeAll = false;
				includeTriggers = true;
			}
			if (argParser.Exists("includeviews") || argParser.Exists("iv"))
			{
				includeAll = false;
				includeViews = true;
			}

			// Check if we want to include everything;
			if (includeAll)
			{
				includeConstraints=true;
				includeFunctions=true;
				includeProcs=true;
				includeTables=true;
				includeTriggers=true;
				includeViews=true;
			}

			// Try and connect to the databases
			DaBCoS.Engine.SqlServer server1 = new DaBCoS.Engine.SqlServer(connect1);
			Console.Write("Testing connection to first database...");
			try
			{
				server1.Connect();
			}
			catch(System.Data.SqlClient.SqlException)
			{
				Console.WriteLine("EXCEPTION: Error connecting to connection.");
				return;
			}
			Console.WriteLine("connected.");
			Console.Write("Testing connection to second database...");
			DaBCoS.Engine.SqlServer server2 = new DaBCoS.Engine.SqlServer(connect2);
			try
			{
				server2.Connect();
			}
			catch(System.Data.SqlClient.SqlException)
			{
				Console.WriteLine("EXCEPTION: Error connecting to connection.");
				return;
			}
			Console.WriteLine("connected.");

			// Compare
			DaBCoS.Engine.DatabaseDifferences dbDifferences = new DaBCoS.Engine.DatabaseDifferences();
			DaBCoS.Engine.Compare dbCompare = new DaBCoS.Engine.Compare();
			if (includeConstraints)
			{
				Console.Write("Comparing constraints...");
				dbDifferences.ConstraintDifferences = dbCompare.CompareSchemaObjects(server1, server2, DaBCoS.Engine.Difference.DatabaseObjectType.Constraint);
				Console.WriteLine("done.");
			}
			if (includeTables)
			{
				Console.Write("Comparing tables...");
				dbDifferences.TableDifferences = dbCompare.CompareTables(server1, server2);
				Console.WriteLine("done.");
			}
			if (includeProcs)
			{
				Console.Write("Comparing stored procedures...");
				dbDifferences.StoredProcDifferences = dbCompare.CompareSchemaObjects(server1, server2, DaBCoS.Engine.Difference.DatabaseObjectType.StoredProcedure);
				Console.WriteLine("done.");
			}
			if (includeViews)
			{
				Console.Write("Comparing views...");
				dbDifferences.ViewDifferences = dbCompare.CompareSchemaObjects(server1, server2, DaBCoS.Engine.Difference.DatabaseObjectType.View);
				Console.WriteLine("done.");
			}
			if (includeFunctions)
			{
				Console.Write("Comparing functions...");
				dbDifferences.FunctionDifferences = dbCompare.CompareSchemaObjects(server1, server2, DaBCoS.Engine.Difference.DatabaseObjectType.Function);
				Console.WriteLine("done.");
			}
			if (includeTriggers)
			{
				Console.Write("Comparing triggers...");
				dbDifferences.TriggerDifferences = dbCompare.CompareSchemaObjects(server1, server2, DaBCoS.Engine.Difference.DatabaseObjectType.Trigger);
				Console.WriteLine("done.");
			}

			// Save to file
			Console.WriteLine("Saving results to file: " + fileName);
			dbDifferences.Save(fileName);
			
			Console.WriteLine("Database compare completed");
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
