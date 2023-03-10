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

<<<<<<< HEAD
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
=======
public class SQLite
{
	public SQLite() { }

	public static List<CMS.vibdata> ReadCMSSQLite(string path)
	{
		using IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
			.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
				.Build();
		var list = fsql.Select<CMS.vibdata>().ToList();

		return list;
>>>>>>> b830519e2efec72becf01ae3a280532a8887a16b
	}
	public static List<TMS.vibdata> ReadTMSSQLite(string path)
	{
		using IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
			.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
				.Build();
		var list = fsql.Select<TMS.vibdata>().ToList();

		return list;
	}
	public static List<BMS.vibdata> ReadBMSSQLite(string path)
	{
		using IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
			.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
				.Build();
		var list = fsql.Select<BMS.vibdata>().ToList();
		fsql.Dispose();
		return list;
	}


}

