using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorShared.Pages;

public partial class CMS
{
	string title = "Seeting";
	bool _visible = false;
	string directoryPath = "/home/data";

	[Inject] IPlatformNameProvider platformNameProvider { get; set; }

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



	int i = 0;
	string editId;
	record ItemData(string Id, string Age, string Address)
	{
		public string Name { get; set; }
	};

	ItemData[] listOfData = { };

	void addRow()
	{
		listOfData = listOfData.Append(new($"{i}", "32", $"London, Park Lane no. {i}") { Name = $"Edward King {i}" });
		i++;
	}

	void deleteRow(string id)
	{
		listOfData = listOfData.Where(d => d.Id != id).ToArray();
	}

	void startEdit(string id)
	{
		editId = id;
	}

	void stopEdit()
	{
		var editedData = listOfData.FirstOrDefault(x => x.Id == editId);
		Console.WriteLine(JsonSerializer.Serialize(editedData));
		editId = null;
	}

	protected override void OnInitialized()
	{
		addRow();
		addRow();
	}
}


