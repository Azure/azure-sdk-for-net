// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Projects;

public static class ProjectInfrastructureConfiguration
{
    /// <summary>
    /// Adds a connections and CM ID to the config system.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="cm"></param>
    /// <returns></returns>
    public static IConfigurationBuilder AddProjectClientConfiguration(this IConfigurationBuilder builder, ProjectInfrastructure cm)
    {
        builder.AddAzureProjectConnections(cm.Connections);
        builder.AddProjectId(cm.ProjectId);
        return builder;
    }

    /// <summary>
    /// Adds the ProjectClient to DI.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="cm"></param>
    /// <returns></returns>
    public static IHostApplicationBuilder AddProjectClient(this IHostApplicationBuilder builder, ProjectInfrastructure cm)
    {
        builder.Services.AddSingleton(new ProjectClient(cm.Connections));
        return builder;
    }
}
