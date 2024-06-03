namespace MauiAppTest.Core.Extensions;

public static class GeneralExtension
{
    public static bool IsNullOrEmptyList<T>(this List<T> parameter)
    {
        if (parameter == null && !parameter.Any())
        {
            return true;
        }

        return false;
    }
}
