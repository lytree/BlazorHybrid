using BlazorShared;

namespace BlazorServerApp;

public class PlatformNameProvider : IPlatformNameProvider
{
    public string GetPlatformName() => "ASP.NET Core Blazor Server";

	public bool IsWebPlatfor()
	{
		return true;
	}

	public string UploadOrSelectDirectory()
	{
		throw new NotImplementedException();
	}
}
