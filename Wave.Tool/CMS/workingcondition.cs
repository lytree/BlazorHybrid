using FreeSql.DatabaseModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;

namespace Wave.Tool.CMS
{

	[Table(DisableSyncStructure = true,Name ="workingcondition")]
	public partial class workingcondition
	{

		[Column(IsPrimary = true)]
		public int id { get; set; }


		public int? datatag { get; set; }


		public byte[] wave { get; set; }


		public float? indexmean { get; set; }


		public float? indexmin { get; set; }


		public float? indexmax { get; set; }


		public float? rmsvalue { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string pathname { get; set; }


		public int? samplingrate { get; set; }


		public int? datatype { get; set; }

		[Column(DbType = "TIMESTAMP")]
		public string measdate { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string measdefid { get; set; }


		public int? real_chno { get; set; }


		public int? chno { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string equipment_id { get; set; }


		public int? datalength { get; set; }


		public int? senoralarm { get; set; }

	}

}
