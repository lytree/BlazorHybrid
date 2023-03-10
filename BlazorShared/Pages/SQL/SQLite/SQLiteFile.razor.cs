using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Pages;

public partial class SQLiteFile
{
	string title = "Seeting";
	bool _visible = false;
	string directoryPath = "/home/data";

	[Inject] public IPlatformNameProvider platformNameProvider { get; set; }

	private void OpenDialog()
	{
		var path = platformNameProvider.UploadOrSelectDirectory();
		if (!string.IsNullOrEmpty(path))
		{
			directoryPath = path;
		}

	}
	private void HandleOk(MouseEventArgs e)
	{
		_visible = false;
	}

	private void HandleCancel(MouseEventArgs e)
	{
		_visible = false;
	}
}


