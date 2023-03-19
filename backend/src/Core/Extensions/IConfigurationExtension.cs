using Core.Configuration;
using Microsoft.Extensions.Configuration;

namespace Core.Extensions;

public static class ConfigurationExtension
{
    public static Settings GetSetting(this IConfiguration configuration)
    {
        var setting = configuration.Get<Settings>();

        return setting ?? throw new NullReferenceException("The environment variables cannot be null.");
    }
}