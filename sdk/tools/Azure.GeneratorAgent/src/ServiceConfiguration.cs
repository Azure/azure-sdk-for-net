// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Commands;
using Azure.GeneratorAgent.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.GeneratorAgent.Configuration;

/// <summary>
/// Configuration for application services.
/// </summary>
public static class ServiceConfiguration
{
    /// <summary>
    /// Adds application services to the service collection.
    /// </summary>
    /// <param name="services">Service collection to configure.</param>
    /// <param name="configuration">Application configuration.</param>
    /// <returns>Configured service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);

        services.AddTransient<RootCommandFactory>();

        services.AddSingleton<SdkValidator>();
        services.AddSingleton<GitService>();

        return services;
    }
}