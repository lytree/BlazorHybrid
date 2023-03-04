using FreeSql.DatabaseModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;

namespace Wave.Tool
{

	[Table(DisableSyncStructure = true, Name = "alarminfo")]
	public partial class alarminfo
	{

		[Column(IsPrimary = true)]
		public int id { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string windfarmid { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string fantype { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string equipment_id { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string fandesc { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string alarmtime { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string alarmlocation { get; set; }


		public int? alarmlevel { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string alarmcode { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string alarmdesc { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string alarmstrategy { get; set; }


		public float? alarmlimit { get; set; }


		public int? faulttype { get; set; }


		public int? vibdataid { get; set; }

		[Column(DbType = "VARCHAR")]
		public string alarmvalue { get; set; }

	}

}
