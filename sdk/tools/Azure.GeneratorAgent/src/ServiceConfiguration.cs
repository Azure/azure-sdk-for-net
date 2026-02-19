// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.GeneratorAgent.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
    /// <param name="projectPath">SDK project path from CLI args. Null when no subcommand requires Copilot (e.g. --help).</param>
    /// <returns>Configured service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration, string? projectPath)
    {
        services.AddSingleton(configuration);

        services.AddHttpClient<GitService>("GitService", (serviceProvider, client) =>
        {
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Azure-GeneratorAgent/1.0");
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.MaxResponseContentBufferSize = 1_000_000;
        });

        services.AddSingleton<ValidationService>();
        services.AddSingleton<FileService>();

        services.AddSingleton<AppSettings>();

        if (!string.IsNullOrEmpty(projectPath))
        {
            services.AddSingleton(provider =>
            {
                var logger = provider.GetRequiredService<ILoggerFactory>().CreateLogger<CopilotService>();
                var settings = provider.GetRequiredService<AppSettings>();

                return CopilotService.CreateAsync(projectPath, logger, settings);
            });
        }

        services.AddTransient<RootCommandFactory>();

        return services;
    }
}
