
using MauiAppTest.Infrastructure;
using MauiAppTest.Pages;
using MauiAppTest.ViewModels;
using Microsoft.Maui.ApplicationModel;

namespace MauiAppTest;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new EntryUserPage();
	}

  	protected override void OnStart()
	{
		this.UserAppTheme = AppTheme.Light;
  	}
}
