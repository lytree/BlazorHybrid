using FreeSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave.Tool;

public class SQLite
{
	public static List<Dictionary<string, object>> ReadCMSSQLite(string path)
	{
		IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
		   .UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
			   .Build();
		return fsql.Ado.Query<Dictionary<string, object>>("select * from main.vibdata").ToList();
	}
	public static List<Dictionary<string, object>> ReadTMSSQLite(string path)
	{
		IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
		   .UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
			   .Build();
		return fsql.Ado.Query<Dictionary<string, object>>("select * from main.vibdata").ToList();
	}
	public static List<Dictionary<string, object>> ReadBMSSQLite(string path)
	{
		IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
		   .UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
			   .Build();
		return fsql.Ado.Query<Dictionary<string, object>>("select * from main.vibdata").ToList();
	}

}
