using System;
using System.Windows;
using AntDesign.ProLayout;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlazorConfiguration;
using BlazorConfiguration.Manager;
using BlazorConfiguration.Repository;
using BlazorShared;
using BlazorShared.Data;
using FreeSql;
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
			serviceCollection.AddAutofac();

			serviceCollection.Configure<ProSettings>(x =>
			{
				x.Title = "Ant Design Pro";
				x.NavTheme = "light";
				x.Layout = "side";
				x.PrimaryColor = "daybreak";
				x.ContentWidth = "Fluid";
				x.HeaderHeight = 64;
				x.FooterRender = false;
			});

			BuildFreeSQLs(serviceCollection);
			CreateAutoMapper(serviceCollection);
			serviceCollection.AddSingleton<IPlatformNameProvider, PlatformNameProvider>();
			Resources.Add("services", new AutofacServiceProvider(RegisterService(serviceCollection)));

			InitializeComponent();
		}
		private void BuildFreeSQLs(ServiceCollection services)
		{
			Func<IServiceProvider, IFreeSql<ConfigurationFlag>> config = r =>
			{
				IFreeSql<ConfigurationFlag> fsql1 = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, @"Data Source=config.db")
				.UseAutoSyncStructure(true) //自动同步实体结构【开发环境必备】，FreeSql不会扫描程序集，只有CRUD时才会生成表。
				.UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
					.Build<ConfigurationFlag>();
				return fsql1;
			};
			services.AddSingleton<IFreeSql<ConfigurationFlag>>(config);
		}

		private void CreateAutoMapper(ServiceCollection services)
		{
			services.AddAutoMapper(typeof(SharedProfile));
			services.AddAutoMapper(typeof(ConfigurationProfile));
		}

		private IContainer RegisterService(ServiceCollection services)
		{
			var container = new ContainerBuilder();
			container.RegisterType<MenuService>();
			container.RegisterType<MenuManager>();
			container.RegisterType<MenuRepository>();
			container.Populate(services);

			return container.Build();

		}
	}
}
