namespace MauiAppTest.Services.Interfaces;

public interface ILoadingService
{
    Task Show(string message = "Loading...");

    Task Hide();
}
