using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlazorShared;
using BlazorShared.Data;
using BlazorWasmApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAntDesign();
builder.ConfigureContainer(new AutofacServiceProviderFactory(AutofacConfiguration.ConfigureContainer));
builder.Services.AddSingleton<IPlatformNameProvider, PlatformNameProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

