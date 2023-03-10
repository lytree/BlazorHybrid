using AntDesign;
using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wave.Tool;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorShared.Pages.SQL.Wave;

public partial class WaveLine
{
	IChartComponent chartLine;
	object[] data;
	LineConfig config4 = new LineConfig
	{
		Title = new AntDesign.Charts.Title
		{
			Visible = true,
			Text = "多折线图"
		},
		Description = new Description
		{
			Visible = true,
			Text = "指定折线颜色"
		},
		Padding = "auto",
		ForceFit = true,
		XField = "date",
		YField = "value",
		YAxis = new ValueAxis
		{
			Label = new BaseAxisLabel()
		},
		Legend = new Legend
		{
			Position = "right-top"
		},
		Slider = new Slider {
			Start = 0.1,
			End =100,
		},
		SeriesField = "measdefid",
		Color = new string[] { "#1979C9", "#D62A0D", "#FAA219" },
		Responsive = true,
	};



	protected override async Task OnInitializedAsync()
	{

		data = budilData();

		//await chartLine.ChangeData(data);

		await base.OnInitializedAsync();
	}
	private object[] budilData()
	{
		var datas = SQLite.ReadTMSSQLite(@"D:\天津市天津城区宝坻区大唐风电场\CMSDATA\TOWERDATA\天津市天津城区宝坻区大唐风电场\2023-01\10000001\2023-01-01\天津市天津城区宝坻区大唐风电场_10000001_2023-01-01-00-00-01-554.tms");
		List<object> data = new();
		foreach (var item in datas)
		{

			var floats = WaveUtils.ToFloat(item.wave);
			Enumerable.Range(0, floats.Length).ForEach(num =>
			{
				data.Add(new
				{
					value = floats[num],
					measdefid = item.measdefid,
					date = ((item.datalength / item.samplingrate * 1.0) / item.datalength) * num
				});
			});


		}
		return data.ToArray();
	}
}

