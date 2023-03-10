using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Pages;

public partial class SQLiteFile
{
	string title = "Seeting";
	bool _visible = false;
	string directoryPath = "/home/data";

	[Inject] public IPlatformNameProvider platformNameProvider { get; set; }
	protected override void OnInitialized()
	{

		_provinces = new List<Organization>()
		{
			new Organization()
			{
				Id = 1,
				Name = "Zhejiang",
				Cities = new List<Machine>()
				{
					new Machine { Id = 100, Name = "Hangzhou" },
					new Machine { Id = 101, Name = "Ningbo" },
					new Machine { Id = 102, Name = "Wenzhou" }
				}
			},
			new Organization()
			{
				Id = 2,
				Name = "Jiangsu",
				Cities = new List<Machine>()
				{
					new Machine { Id = 200, Name = "Nanjing" },
					new Machine { Id = 201, Name = "Suzhou" },
					new Machine { Id = 202, Name = "Zhenjiang" }
				}
			},
			new Organization()
			{
				Id = 3,
				Name = "Beijing"
			},
			new Organization()
			{
				Id = 4,
				Name = "Shanghai",
				Cities = null
			}
		};
		_selectedProvince = 1;
		_selectedCity = 100;
	}























	class Organization
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Machine> Cities { get; set; } = new List<Machine>();
	}

	class Machine
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	List<Organization> _provinces;
	List<Machine> _cities = new List<Machine>();

	int? _selectedProvince;
	int? _selectedCity;



	private void OnSelectedItemChangedHandler(Organization value)
	{
		_cities = value?.Cities;
		if (_cities?.Any(x => x.Id == _selectedCity) != true)
		{
			_selectedCity = _cities?.FirstOrDefault()?.Id;
		}
	}













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



	record ItemData(string Id, string Name, string Context, int Status, string Createtime);


	ItemData[] listOfData = { };

}


