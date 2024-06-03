using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MauiAppTest.Infrastructure;
using DotNet.Meteor.HotReload.Plugin;
using UraniumUI;
using MauiAppTest.ViewModels;
using MauiAppTest.Services.Interfaces;
using MauiAppTest.Services.Implementations;
using InputKit.Handlers;
using MauiAppTest.Infrastructure.Repositories.Realm.Context;
using MauiAppTest.Infrastructure.Repositories.Realm.Interfaces;
using MauiAppTest.Infrastructure.Repositories.Realm.Implementations;
using Realms;

namespace MauiAppTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseUraniumUI()
			.UseUraniumUIMaterial()
			.ConfigureMauiHandlers(handlers =>
			{
				// Add following line:
				handlers.AddInputKitHandlers();
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

			builder.Services.AddSingleton<IRandomUserRepository, RandomUserRepository>();			
			builder.Services.AddSingleton<IDataBaseContextRealm, DataBaseContextRealm>();

			builder.Services.AddSingleton<IUserRepository, UserRepository>();
			builder.Services.AddSingleton<ILocationRepository, LocationRepository>();				

			builder.Services.AddTransient<ILoadingService, LoadingService>();

			builder.Services.AddTransient<EntryUserViewModel>();
			builder.Services.AddTransient<ListUserViewModel>();

			builder.Services.AddSingleton<IRandomUserService, RandomUserService>();

			builder.Services.AddSingleton<Realm>();
			

#if DEBUG
		builder.EnableHotReload();
		builder.Logging.AddDebug();
#endif

		var app = builder.Build();

		Startup.ServicesProvider = app.Services;

		return app;
	}
}
