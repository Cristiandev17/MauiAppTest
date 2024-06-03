using MauiAppTest.Popups;
using MauiAppTest.Services.Interfaces;
using Mopups.Interfaces;
using Mopups.Services;

namespace MauiAppTest.Services.Implementations;

public class LoadingService : ILoadingService
{
    private readonly IPopupNavigation navigation;

    public LoadingService()
    {
        navigation = MopupService.Instance;
    }

    public async Task Hide()
    {
        await navigation.PopAsync(true);
    }

    public async Task Show(string message)
    {
        try
        {
            await navigation.PushAsync(new LoadingPopup(message), true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
