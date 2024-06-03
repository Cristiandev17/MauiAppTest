namespace MauiAppTest;

public class Startup
{
    public static IServiceProvider? ServicesProvider { get; set; }
    
    public static void Initialize(IServiceProvider serviceProvider)
    {
        ServicesProvider = serviceProvider;
    }

    public static T GetService<T>()
    {
       return ServicesProvider.GetService<T>();
    }
}
