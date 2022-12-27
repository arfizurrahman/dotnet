using EasyDinner.Application.Services.Authentication.Commands;
using EasyDinner.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace EasyDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        return services;
    }
}