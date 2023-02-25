using BlazorShared;

namespace BlazorWPFApp;

public class PlatformNameProvider : IPlatformNameProvider
{
    public string GetPlatformName()
    {
        return "ASP.NET Core Blazor WPF";
    }
}
