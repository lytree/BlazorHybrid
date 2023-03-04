using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave.Tool
{
	public class SQLite
	{
		public SQLite() { }

		public static List<Wave.Tool.CMS.vibdata> ReadCMSSQLite(string path)
		{
			IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
				.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
					.Build();
			return fsql.Select<Wave.Tool.CMS.vibdata>().ToList();
		}
		public static List<Wave.Tool.TMS.vibdata> ReadTMSSQLite(string path)
		{
			IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
				.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
					.Build();
			return fsql.Select<Wave.Tool.TMS.vibdata>().ToList();
		}
		public static List<Wave.Tool.BMS.vibdata> ReadBMSSQLite(string path)
		{
			IFreeSql fsql = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $@"Data Source={path}")
				.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
					.Build();
			return fsql.Select<Wave.Tool.BMS.vibdata>().ToList();
		}
	}
}
