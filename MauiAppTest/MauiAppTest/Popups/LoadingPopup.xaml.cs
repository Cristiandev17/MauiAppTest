using Mopups.Pages;

namespace MauiAppTest.Popups;

public partial class LoadingPopup : PopupPage
{
	public LoadingPopup(string message)
	{
		InitializeComponent();
		lblLoading.Text = message;
	}
}