using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;

namespace DaBCoS.Engine 
{
	/// <summary>
	/// DaBCoS Database Connection Interface for MS SQL Server databases
	/// </summary>
	public class SqlServer 
	{

		#region Instance Members

		private readonly string databaseServerName = "SQL Server";
		private string login;
		private string password;
		private string server;
		private string versionDescription;
		private string interfaceFile = string.Empty;
		private string _appPath;
		private SqlConnection conn;
		private SqlAuthentication authenticationType;
		private SqlVersion version = SqlVersion.SqlServerUnknown;		

		/*
		 * Delegates Members 
		 */		
		private LogFunction Logger;

		#endregion Instance Members

		#region Properties

		public SqlConnection Connection 
		{
			get { return conn; }
		}

		public string Login 
		{
			get { return login; }
			set { login = value; }
		}

		public string Password 
		{
			get { return password; }
			set { password = value; }
		}

		public string Server 
		{
			get { return server; }
			set { server = value; }
		}

		public SqlAuthentication AuthenticationType 
		{
			get { return authenticationType; }
			set { authenticationType = value; }
		}

		public SqlVersion Version 
		{
			get { return version; }			
		}

		public string VersionName 
		{
			get { return versionDescription; }
		}

		public bool Connected 
		{
			get { return conn.State == ConnectionState.Open; }
		}

		#endregion Properties

		#region Constructor / Destructor

		public SqlServer()
		{
			_appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
			conn = new SqlConnection();
		}

		public SqlServer(string connectionString)
		{
			_appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
			conn = new SqlConnection(connectionString);
		}

		#endregion Constructor / Destructor

		#region Methods

		/// <summary>
		/// Write a message to the log function specified in the delegate
		/// </summary>
		/// <param name="message">Message to log</param>
		private void WriteLog(string message) 
		{
			if (Logger != null) Logger(message);
		}

		/// <summary>
		/// Detect and memorize the connected SQL Server version
		/// </summary>
		private void DetectServerVersion() 
		{
			string sqlCmd = string.Empty;
			string result;	
			
			/*
			 * Find the query to use to get the version
			 */
			WriteLog("Detecting Sql Server version...");
			XPathDocument vd = new XPathDocument(_appPath + "General.VersionDetect.xml");
			XPathNavigator nav = vd.CreateNavigator();
			XPathNodeIterator nodeIterator = nav.Select("/databases/database[@name='" + databaseServerName + "']/query");
			while (nodeIterator.MoveNext()) 
			{
				sqlCmd = nodeIterator.Current.GetAttribute("value", string.Empty);
			}

			/*
			 * Execute the query
			 */
			SqlCommand cmd = new SqlCommand(sqlCmd, conn);
			try 
			{
				result = (string)cmd.ExecuteScalar();
			} 
			catch (Exception) 
			{
				result = string.Empty;
			}
			finally 
			{				
				cmd.Dispose();
			}
			if (result == null) result = string.Empty;			
			result = result.ToLower();

			/*
			 * Perform matching against the xml version file
			 */
			WriteLog("Loading VersionsInfo module...");
			vd = new XPathDocument(_appPath + "SqlServer.VersionsInfo.xml");
			nav = vd.CreateNavigator();
			nodeIterator = nav.Select("/databases/database[@name='" + databaseServerName + "']/version");
			while (nodeIterator.MoveNext()) 
			{
                string fromXML = nodeIterator.Current.GetAttribute("identifier", string.Empty);
                string fromID = nodeIterator.Current.GetAttribute("id", string.Empty);
				if (result.StartsWith(fromXML) )
				{
                    version = (SqlVersion)Enum.Parse(version.GetType(), fromID, false);
					versionDescription	= nodeIterator.Current.GetAttribute("name", string.Empty);
					interfaceFile		= nodeIterator.Current.GetAttribute("interface", string.Empty);				
				}			
			}

			WriteLog(String.Format("Detected Sql Server Version: {0}.", versionDescription));
		}

		/// <summary>
		/// Get the command to issue to the server from the xml interface file
		/// </summary>
		/// <param name="cmdId">Command unique identifier</param>
		/// <returns>A string containing the SQL command</returns>
		private string GetSqlCommand(string cmdId) 
		{
			string sqlCmd = string.Empty;

			XPathDocument doc = new XPathDocument(_appPath + interfaceFile);
			XPathNavigator nav = doc.CreateNavigator();
			XPathNodeIterator nodeIterator = nav.Select("/interface/add[@key='" + cmdId + "']");
			while (nodeIterator.MoveNext()) 
			{
				sqlCmd = nodeIterator.Current.GetAttribute("value", string.Empty);
			}						

			return sqlCmd;
		}

		/*
		 * Public Methods
		 */
		/// <summary>
		/// Set the log function to use
		/// </summary>
		/// <param name="logWriter">User defined log function</param>
		public void SetLogger(LogFunction logWriter) 
		{
			Logger = logWriter;
		}
		
		/// <summary>
		/// Connect to the database server
		/// </summary>
		public void Connect() 
		{
			// CHeck if the connection string has already been set
			if (conn.ConnectionString.Length==0)
			{
				if (authenticationType == SqlAuthentication.SQLSever) 
				{
					conn.ConnectionString = String.Format("SERVER={0}; UID={1}; PWD={2};", server, login, password);
				} 
				else 
				{
					conn.ConnectionString = String.Format("SERVER={0}; Integrated Security=SSPI;", server);
					login = Environment.UserName;
				}
			}

			WriteLog(String.Format("Connecting to SQL Server {0}...", server));
			conn.Open();

			if (conn.State == ConnectionState.Open) 
			{
				WriteLog(String.Format("Connected to {0}.", server));

				DetectServerVersion();

				if (version == SqlVersion.SqlServerUnknown) 
				{
					conn.Close();
					throw new Exception("Unsupported version of SQL Server");
				}			
			} 
			else 
			{
				WriteLog("Connection failed.");
			}
		}

		/// <summary>
		/// Load all the available databases into an array list
		/// </summary>
		/// <returns>An array of string containing all the databases found</returns>
		public ArrayList GetDatabases() 
		{
			ArrayList alResult = new ArrayList();
 
			if (conn.Database != "master") 
			{				
				conn.ChangeDatabase("master");
			}

			SqlCommand sqlCmd = new SqlCommand(GetSqlCommand("qryDatabases"), conn);
			SqlDataReader sqlDR;
			sqlDR = sqlCmd.ExecuteReader();			
			while (sqlDR.Read()) 
			{
				alResult.Add(sqlDR[0].ToString());
			}			
			sqlDR.Close();	
			sqlCmd.Dispose();

			return alResult;
		}

		/// <summary>
		/// Load all the tables into an array list
		/// </summary>
		/// <returns>An array of string containing all the tables found</returns>
		public ArrayList GetObjectList(Difference.DatabaseObjectType databaseObjectType) 
		{
			string xmlCommandName;
			ArrayList alResult = new ArrayList();

			switch(databaseObjectType)
			{
				case Difference.DatabaseObjectType.Constraint:
					xmlCommandName = "qryConstraints";
					break;
				case Difference.DatabaseObjectType.Function:
					xmlCommandName = "qryFunctions";
					break;
				case Difference.DatabaseObjectType.StoredProcedure:
					xmlCommandName = "qryProcs";
					break;
				case Difference.DatabaseObjectType.Table:
					xmlCommandName = "qryTables";
					break;
				case Difference.DatabaseObjectType.Trigger:
					xmlCommandName = "qryTriggers";
					break;
				case Difference.DatabaseObjectType.View:
					xmlCommandName = "qryViews";
					break;
				default:
					throw new Exception("Unknown database object type");
			}

			SqlCommand sqlCmd = new SqlCommand(String.Format(GetSqlCommand(xmlCommandName), conn.Database), conn);
			
			SqlDataReader sqlDR;
			sqlDR = sqlCmd.ExecuteReader();
			
			while (sqlDR.Read()) 
			{				
				alResult.Add(sqlDR[0].ToString());
			}
			
			sqlDR.Close();			
			sqlCmd.Dispose();

			return alResult;
		}

		/// <summary>
		/// Load all the tables into an array list
		/// </summary>
		/// <returns>An array of string containing all the tables found</returns>
		public ArrayList GetTables() 
		{
			ArrayList alResult = new ArrayList();

			SqlCommand sqlCmd = new SqlCommand(String.Format(GetSqlCommand("qryTables"), conn.Database), conn);
			
			SqlDataReader sqlDR;
			sqlDR = sqlCmd.ExecuteReader();
			
			while (sqlDR.Read()) 
			{				
				alResult.Add(sqlDR[0].ToString());
			}
			
			sqlDR.Close();			
			sqlCmd.Dispose();

			return alResult;
		}

		/// <summary>
		/// Load all the columns in a table into an array list
		/// </summary>
		/// <param name="sTableName">Table to scan for colums</param>
		/// <returns>
		/// An array of string containing all the columns found,  
		/// each one with its properties
		/// </returns>
		public ArrayList GetColumns(string sTableName) 
		{
			StringBuilder sColumDef;
			ArrayList alResult = new ArrayList();

			SqlCommand sqlCmd = new SqlCommand(String.Format(GetSqlCommand("qryColumns"), sTableName), conn);
			
			SqlDataReader sqlDR = null;
			try 
			{
				sqlDR = sqlCmd.ExecuteReader();
			
				while (sqlDR.Read()) 
				{
					sColumDef = new StringBuilder();
				
					// Name
					sColumDef.Append("[" + sqlDR["col_name"].ToString() + "]");
				
					// Calculated
					if (sqlDR["col_iscomputed"].ToString() == "1") 
					{
						sColumDef.Append(" AS " + sqlDR[17].ToString());
						alResult.Add(sColumDef);
						continue;
					}

					// Data Type
					sColumDef.Append(" [" + sqlDR["col_typename"].ToString() + "]");
				
					// Length
					if (sqlDR["col_typename"].ToString() == "char" || 
						sqlDR["col_typename"].ToString() == "varchar" || 
						sqlDR["col_typename"].ToString() == "nchar" || 
						sqlDR["col_typename"].ToString() == "nvarchar") 
					{
						if (sqlDR["col_len"].ToString() != string.Empty) 
						{
							sColumDef.Append(" (" + sqlDR["col_len"].ToString() + ")");
						} 
					}
				
					// Precision, Scale
					if (sqlDR["col_typename"].ToString() == "decimal" || 
						sqlDR["col_typename"].ToString() == "numeric") 
					{
						sColumDef.Append("(" + sqlDR["col_prec"].ToString());
						sColumDef.Append(", " + sqlDR["col_scale"].ToString() + ")");
					}

					// Identity
					if (sqlDR["col_identity"].ToString() == bool.TrueString) 
					{
						sColumDef.Append(" IDENTITY(" + sqlDR["col_seed"].ToString());
						sColumDef.Append(", " + sqlDR["col_increment"].ToString() + ")");
					}

					// Nullable
					if (sqlDR["col_null"].ToString() == bool.TrueString) 
					{
						sColumDef.Append(" NULL");
					} 
					else 
					{
						sColumDef.Append(" NOT NULL");
					}

					// Default
					if (sqlDR["col_dridefname"].ToString() != string.Empty) 
					{
						sColumDef.Append(" DEFAULT " + sqlDR["text"].ToString());
					}

					alResult.Add(sColumDef);
				}
			} 
			catch (SqlException) 
			{
				sColumDef = new StringBuilder();
				alResult.Add(sColumDef);
			}
			finally 
			{			
				if (sqlDR != null) sqlDR.Close();			
				sqlCmd.Dispose();
			}
			return alResult;			
		}	

		/// <summary>
		/// Load all the views into an array list
		/// </summary>
		/// <returns>An array of string containing all the views found</returns>
		public ArrayList GetViews() 
		{
			ArrayList alResult = new ArrayList();

			SqlCommand sqlCmd = new SqlCommand(GetSqlCommand("qryViews"), conn);
			
			SqlDataReader sqlDR;
			sqlDR = sqlCmd.ExecuteReader();
			
			while (sqlDR.Read()) 
			{				
				alResult.Add(sqlDR[0].ToString());
			}
			
			sqlDR.Close();		
			sqlCmd.Dispose();

			return alResult;
		}	

		/// <summary>
		/// Load the stored procedure list
		/// </summary>
		/// <returns>An array of string containing all the stored procedures found</returns>
		public ArrayList GetStoredProcedures() 
		{
			ArrayList alResult = new ArrayList();

			SqlCommand sqlCmd = new SqlCommand(GetSqlCommand("qryProcs"), conn);
			
			SqlDataReader sqlDR;
			sqlDR = sqlCmd.ExecuteReader();
			
			while (sqlDR.Read()) 
			{				
				alResult.Add(sqlDR[0].ToString());
			}
			
			sqlDR.Close();		
			sqlCmd.Dispose();

			return alResult;
		}

		
		/// <summary>
		/// Load functions list
		/// </summary>
		/// <returns>An array of string containing all the functions found</returns>
		public ArrayList GetFunctions() 
		{
			ArrayList alResult = new ArrayList();

			SqlCommand sqlCmd = new SqlCommand(GetSqlCommand("qryFunctions"), conn);
			
			SqlDataReader sqlDR;
			sqlDR = sqlCmd.ExecuteReader();
			
			while (sqlDR.Read()) 
			{				
				alResult.Add(sqlDR[0].ToString());
			}
			
			sqlDR.Close();		
			sqlCmd.Dispose();

			return alResult;
		}	

		/// <summary>
		/// Load the definition (source code) of an object
		/// </summary>
		/// <param name="sObject">object name</param>
		/// <returns>A string contining the object's source code</returns>
		public string GetObjectDefinition(string sObject) 
		{
			string result;
			SqlCommand sqlCmd = null;
			SqlDataReader dr = null;
			StringBuilder code = new StringBuilder();

			try 
			{
				sqlCmd = new SqlCommand(String.Format(GetSqlCommand("qryObjectDefinition"), sObject), conn);
				dr = sqlCmd.ExecuteReader();
				
				while (dr.Read()) 
				{
					code.Append(dr[0].ToString());
				}
				result = code.ToString();				
			} 
			catch (Exception) 
			{
				result = string.Empty;
			}
			finally 
			{					
				if (dr != null) dr.Close();
				if (sqlCmd != null) sqlCmd.Dispose();
			}
			
			if (result == null) result = string.Empty;
			return result;
		}

		#endregion Methods

	}
}
