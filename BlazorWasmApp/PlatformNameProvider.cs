using BlazorShared;

namespace BlazorWasmApp;

public class PlatformNameProvider : IPlatformNameProvider
{
    public string GetPlatformName()
    {
        return "ASP.NET Core Blazor WebAssembly";
    }

	public bool IsWebPlatfor()
	{
		return true;
	}

	public string UploadOrSelectDirectory()
	{
		throw new NotImplementedException();
	}
}
