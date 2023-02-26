using System.Windows;
using AntDesign.ProLayout;
using BlazorShared;
using BlazorShared.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddAntDesign();
            serviceCollection.AddBlazorWebViewDeveloperTools();
	        serviceCollection.Configure<ProSettings>(x =>
	        {
		        x.Title = "Ant Design Pro";
		        x.NavTheme = "light";
		        x.Layout = "side";
		        x.PrimaryColor = "daybreak";
		        x.ContentWidth = "Fluid";
		        x.HeaderHeight = 64;
	        });
            serviceCollection.AddSingleton<WeatherForecastService>();
            serviceCollection.AddSingleton<IPlatformNameProvider,PlatformNameProvider>();
            Resources.Add("services", serviceCollection.BuildServiceProvider());

            InitializeComponent();
        }
    }
}
