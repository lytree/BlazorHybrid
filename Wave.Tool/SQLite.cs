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
	public SQLite() { }

	public static List<CMS.vibdata> ReadCMSSQLite(string path)
	{
		using IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
			.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
				.Build();
		var list = fsql.Select<Wave.Tool.CMS.vibdata>().ToList();

		return list;
	}
	public static List<TMS.vibdata> ReadTMSSQLite(string path)
	{
		using IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
			.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
				.Build();
		var list = fsql.Select<Wave.Tool.TMS.vibdata>().ToList();

		return list;
	}
	public static List<BMS.vibdata> ReadBMSSQLite(string path)
	{
		using IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
			.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
				.Build();
		var list = fsql.Select<Wave.Tool.BMS.vibdata>().ToList();
		fsql.Dispose();
		return list;
	}


}

