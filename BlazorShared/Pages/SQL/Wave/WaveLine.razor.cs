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
		Slider = new Slider
		{
			Start = 0.1,
			End = 100,
		},
		SeriesField = "measdefid",
		Color = new string[] { "#1979C9", "#D62A0D", "#FAA219" },
		Responsive = true,
	};



	protected override async Task OnInitializedAsync()
	{

		data = budilData();


		await base.OnInitializedAsync();
	}
	private object[] budilData()
	{
		var datas = SQLite.ReadTMSSQLite(@"F:\sqlite\新疆伊犁伊宁中核风电场_10000004_2023-02-12-00-00-01-422.tms");
		List<object> data = new();
		foreach (var item in datas)
		{
			Console.WriteLine(item);

			var floats = WaveUtils.ToFloat((byte[])item["wave"]);
			Enumerable.Range(0, floats.Length).ForEach(num =>
			{
				data.Add(new
				{
					value = floats[num],
					measdefid = item["measdefid"],
					date = ((Convert.ToInt32(item["datalength"]) / Convert.ToInt32(item["samplingrate"]) * 1.0) / Convert.ToInt32(item["datalength"])) * num
				});
			});


		}
		return data.ToArray();
	}
}

