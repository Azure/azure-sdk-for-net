// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.AgentServer.Core;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods to register the Responses API server on an
/// <see cref="IHostApplicationBuilder"/>, binding the Foundry credential and endpoint from a single
/// configuration section (the <see cref="System.ClientModel.Primitives.ClientSettings"/> pattern).
/// This is the required entry point in hosted Foundry environments: because response storage and
/// resilient-task storage bind the SAME <see cref="System.ClientModel.Primitives.ClientSettings.Credential"/>
/// and <see cref="ResponsesServerSettings.Endpoint"/> from one section, the two cannot diverge.
/// </summary>
[Experimental("SCME0002")]
public static class ResponsesServerHostExtensions
{
    /// <summary>
    /// Registers the Responses API server SDK services, binding
    /// <see cref="ResponsesServerSettings"/> (including the Foundry credential and endpoint) from the
    /// named configuration section.
    /// </summary>
    /// <param name="host">The host application builder.</param>
    /// <param name="sectionName">The configuration section to bind settings from.</param>
    /// <returns>The host application builder for chaining.</returns>
    public static IHostApplicationBuilder AddResponsesServer(
        this IHostApplicationBuilder host,
        string sectionName)
        => host.AddResponsesServer(sectionName, configureSettings: null);

    /// <summary>
    /// Registers the Responses API server SDK services, binding
    /// <see cref="ResponsesServerSettings"/> from the named configuration section and applying
    /// <paramref name="configureSettings"/> afterward (so code-configured values, including a
    /// hard-coded <see cref="System.ClientModel.Primitives.ClientSettings.CredentialProvider"/>,
    /// win over the section).
    /// </summary>
    /// <param name="host">The host application builder.</param>
    /// <param name="sectionName">The configuration section to bind settings from.</param>
    /// <param name="configureSettings">Optional callback to modify the bound settings.</param>
    /// <returns>The host application builder for chaining.</returns>
    public static IHostApplicationBuilder AddResponsesServer(
        this IHostApplicationBuilder host,
        string sectionName,
        Action<ResponsesServerSettings>? configureSettings)
    {
        Argument.AssertNotNull(host, nameof(host));
        Argument.AssertNotNullOrEmpty(sectionName, nameof(sectionName));

        ResponsesServerSettings settings =
            host.Configuration.GetAzureClientSettings<ResponsesServerSettings>(sectionName);
        configureSettings?.Invoke(settings);

        ResponsesHostedStorage? hostedStorage = null;
        if (FoundryEnvironment.IsHosted)
        {
            // The single identity bound from the section, used for BOTH response and task storage.
            TokenCredential credential = ResolveCredential(settings, sectionName);
            Uri projectEndpoint = settings.Endpoint
                ?? throw new InvalidOperationException(
                    $"A Foundry project endpoint is required for hosted storage. Configure " +
                    $"'{sectionName}:Endpoint'.");

            Uri storageBaseUri = ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri(
                projectEndpoint,
                host.Environment.IsDevelopment());

            hostedStorage = new ResponsesHostedStorage(
                credential,
                projectEndpoint,
                storageBaseUri);
        }

        host.Services.AddResponsesServerCore(settings.ApplyTo, hostedStorage);
        return host;
    }

    private static TokenCredential ResolveCredential(
        ResponsesServerSettings settings,
        string sectionName)
    {
        // GetAzureClientSettings resolves CredentialProvider to a TokenCredential (via the built-in
        // AzureCredentialResolver) for token-credential sections; a code-configured CredentialProvider
        // set through configureSettings wins.
        return settings.CredentialProvider switch
        {
            TokenCredential credential => credential,
            null => throw new InvalidOperationException(
                $"A credential is required for hosted Foundry storage but none was bound from the " +
                $"'{sectionName}' configuration section. Provide a 'Credential' section or set " +
                $"CredentialProvider via the configureSettings callback."),
            _ => throw new InvalidOperationException(
                $"Hosted Foundry storage requires a {nameof(TokenCredential)}; the configured " +
                $"CredentialProvider is '{settings.CredentialProvider.GetType().FullName}'."),
        };
    }
}
