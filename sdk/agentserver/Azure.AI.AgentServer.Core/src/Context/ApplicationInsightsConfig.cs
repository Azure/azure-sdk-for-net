// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Projects;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;

namespace Azure.AI.AgentServer.Core.Context;

/// <summary>
/// Provides configuration for Application Insights telemetry.
/// </summary>
internal static class ApplicationInsightsConfig
{
    /// <summary>
    /// Attempts to configure Application Insights for telemetry collection.
    /// </summary>
    /// <param name="builder">The host application builder.</param>
    /// <param name="appConf">The application configuration.</param>
    /// <returns>A tuple indicating if Application Insights is enabled and the connection string.</returns>
    public static (bool Enabled, string? ConnectionString) TryUseApplicationInsights(
        this IHostApplicationBuilder builder,
        AppConfiguration appConf)
    {
        if (!appConf.AppInsightsEnabled)
        {
            return (false, null);
        }

        var appInsightsConnectionString = appConf.AppInsightsConnectionString;
        if (string.IsNullOrWhiteSpace(appConf.AppInsightsConnectionString) && appConf.FoundryProjectInfo is not null)
        {
            var projectClient = new AIProjectClient(appConf.FoundryProjectInfo.ProjectEndpoint,
                new DefaultAzureCredential());
            try
            {
                appInsightsConnectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();
            }
            catch (Exception e)
            {
                // Ignore any exceptions, we just won't enable App Insights
                Console.WriteLine(
                    $"Failed to get Application Insights connection string from Foundry project. {e.Message}");
            }
        }

        if (!string.IsNullOrWhiteSpace(appInsightsConnectionString))
        {
            builder.Services.AddOpenTelemetry()
                .UseAzureMonitor(o => o.ConnectionString = appInsightsConnectionString);
            return (true, appInsightsConnectionString);
        }

        return (false, null);
    }
}
