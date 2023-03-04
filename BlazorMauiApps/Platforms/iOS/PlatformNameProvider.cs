using BlazorShared;

namespace BlazorMauiApp;

public class PlatformNameProvider : IPlatformNameProvider
{
    public string GetPlatformName() => "iOS";
    public bool IsWebPlatfor()
	{
		return false;
	}

	public string UploadOrSelectDirectory()
	{
		throw new NotImplementedException();
	}
}
