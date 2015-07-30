using System;

namespace DaBCoS.Engine {
	/// <summary>
	/// SQL Server Authentication method
	/// </summary>
	public enum SqlAuthentication : int {
		SQLSever	= 1, 
		NT			= 2
	};

	/// <summary>
	/// Sql Server Version
	/// </summary>
	public enum SqlVersion : int {
		SqlServerUnknown	= -1,
		SqlServer65			= 0,
		SqlServer7			= 1,
		SqlServer2000		= 2,
		SqlServer2005		= 3,
        SqlServer2008       = 4,
        SqlServer2012       = 5,
        SqlServer2014       = 3
	};
}
