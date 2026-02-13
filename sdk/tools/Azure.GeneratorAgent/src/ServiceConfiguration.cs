// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Commands;
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

        services.AddHttpClient<GitService>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Azure-GeneratorAgent/1.0");
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.MaxResponseContentBufferSize = 10 * 1024 * 1024;
        });

        services.AddTransient<RootCommandFactory>();

        services.AddSingleton<ValidationService>();
        services.AddSingleton<GitService>();
        services.AddSingleton<FileService>();

        return services;
    }
}