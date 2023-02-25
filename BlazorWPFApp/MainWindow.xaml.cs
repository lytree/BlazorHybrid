﻿
using BlazorShared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AntDesign.ProLayout;
using BlazorWPFApp;
using BlazorShared.Data;

namespace BlazorHybridWpf
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