using Application.Cryptography;
using Core.Auth;
using Core.Cryptography;
using Infrastructure.Auth;
using Infrastructure.DatabaseProviders;

namespace Api.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection service)
    {
        service.AddScoped<IHashStringWithSha512Service, HashStringWithSha512Service>();
        service.AddScoped<IRoleRepository, RoleRepository>();
        service.AddScoped<IDatabaseProvider, PostgresDatabaseProvider>();
    }
}