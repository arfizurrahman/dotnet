using EasyDinner.Application.Common.Interfaces.Authentication;
using EasyDinner.Application.Common.Interfaces.Persistence;
using EasyDinner.Application.Common.Interfaces.Services;
using EasyDinner.Infrastrcuture.Authentication;
using EasyDinner.Infrastrcuture.Persistence;
using EasyDinner.Infrastrcuture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyDinner.Infrastrcuture;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrcuture(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}