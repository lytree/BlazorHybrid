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

	[Table(DisableSyncStructure = true,Name ="vibdata")]
	public partial class vibdata
	{

		[Column(IsPrimary = true)]
		public int id { get; set; }


		public float? indexxr { get; set; }


		public float? indexmax { get; set; }


		public float? indexmin { get; set; }


		public float? indexmean { get; set; }


		public float? indexeven { get; set; }


		public float? indexp { get; set; }


		public float? indexpp { get; set; }


		public float? runningspeed { get; set; }


		public float? power { get; set; }


		public float? windspeed { get; set; }


		public float? yew { get; set; }


		public int? wavesave { get; set; }


		public byte[] wave { get; set; }


		public int? datatag { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string pathname { get; set; }


		public float? indexc { get; set; }


		public float? senorvoltage { get; set; }


		public float? indexsk { get; set; }


		public float? indexk { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string equipment_id { get; set; }


		public int? chno { get; set; }


		public int? real_chno { get; set; }

		[Column(DbType = "NVARCHAR")]
		public string measdefid { get; set; }

		[Column(DbType = "TIMESTAMP")]
		public string measdate { get; set; }


		public int? datatype { get; set; }


		public int? datalength { get; set; }


		public int? samplingrate { get; set; }


		public float? rmsvalue { get; set; }


		public float? isoa_21_0_10 { get; set; }


		public float? isoa_21_0_200 { get; set; }


		public float? isoa_21_200_300 { get; set; }


		public float? isoa_21_200_500 { get; set; }


		public float? indexkur { get; set; }


		public float? indexi { get; set; }


		public float? indexl { get; set; }


		public int? senoralarm { get; set; }

	}

}
