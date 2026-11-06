// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>Host-builder registration for configuration-bound resilient-task storage.</summary>
[Experimental("SCME0002")]
public static class ResilientTaskHostExtensions
{
    /// <summary>
    /// Adds resilient-task services using the credential and endpoint in
    /// <paramref name="sectionName"/>.
    /// </summary>
    /// <param name="host">The host application builder.</param>
    /// <param name="sectionName">The configuration section name.</param>
    /// <returns>The host application builder.</returns>
    public static IHostApplicationBuilder AddResilientTasks(
        this IHostApplicationBuilder host,
        string sectionName)
        => AddResilientTasksCore(host, sectionName, configureSettings: null);

    /// <summary>
    /// Adds resilient-task services using the named configuration section, then applies
    /// <paramref name="configureSettings"/> so code-based values take precedence.
    /// </summary>
    /// <param name="host">The host application builder.</param>
    /// <param name="sectionName">The configuration section name.</param>
    /// <param name="configureSettings">A callback that overrides bound settings.</param>
    /// <returns>The host application builder.</returns>
    public static IHostApplicationBuilder AddResilientTasks(
        this IHostApplicationBuilder host,
        string sectionName,
        Action<ResilientTaskSettings> configureSettings)
    {
        ArgumentNullException.ThrowIfNull(configureSettings);
        return AddResilientTasksCore(host, sectionName, configureSettings);
    }

    private static IHostApplicationBuilder AddResilientTasksCore(
        IHostApplicationBuilder host,
        string sectionName,
        Action<ResilientTaskSettings>? configureSettings)
    {
        ArgumentNullException.ThrowIfNull(host);
        ArgumentException.ThrowIfNullOrWhiteSpace(sectionName);

        ResilientTaskSettings settings =
            host.Configuration.GetAzureClientSettings<ResilientTaskSettings>(sectionName);
        configureSettings?.Invoke(settings);

        TokenCredential credential = settings.CredentialProvider switch
        {
            TokenCredential tokenCredential => tokenCredential,
            null => throw new InvalidOperationException(
                $"A credential is required for hosted resilient-task storage. Configure " +
                $"'{sectionName}:Credential' or set CredentialProvider in the callback."),
            _ => throw new InvalidOperationException(
                $"Resilient-task storage requires a {nameof(TokenCredential)}; the configured " +
                $"provider is '{settings.CredentialProvider.GetType().FullName}'."),
        };
        Uri endpoint = settings.Endpoint
            ?? throw new InvalidOperationException(
                $"An endpoint is required for hosted resilient-task storage. Configure " +
                $"'{sectionName}:Endpoint'.");

        host.Services.AddResilientTasks(credential, endpoint);
        return host;
    }
}
