using BlazorShared;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace BlazorWPFApp;

public class PlatformNameProvider : IPlatformNameProvider
{
	public string GetPlatformName()
	{
		return "ASP.NET Core Blazor WPF";
	}

	public bool IsWebPlatfor()
	{
		return false;
	}

	public string? UploadOrSelectDirectory()
	{
		var dlg = new CommonOpenFileDialog();
		dlg.IsFolderPicker = true;
		dlg.InitialDirectory ="%USERPROFILE%";

		if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
		{
			return dlg.FileName;
		}
		return null;
	}
}
