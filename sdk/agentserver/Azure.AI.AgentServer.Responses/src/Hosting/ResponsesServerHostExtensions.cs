// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.AgentServer.Core;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods to register the Responses API server on an
/// <see cref="IHostApplicationBuilder"/>, binding the Foundry credential and endpoint from a single
/// configuration section (the <see cref="System.ClientModel.Primitives.ClientSettings"/> pattern).
/// This is the required entry point in hosted Foundry environments: because response storage and
/// resilient-task storage bind the SAME <see cref="System.ClientModel.Primitives.ClientSettings.Credential"/>
/// and <see cref="ResponsesServerSettings.Endpoint"/> from one section, the two cannot diverge.
/// <para>
/// In a hosted Foundry environment, values the section does not provide fall back to the platform:
/// <c>Endpoint</c> defaults to <c>FOUNDRY_PROJECT_ENDPOINT</c>, and an absent <c>Credential</c> section
/// defaults to a <see cref="DefaultAzureCredential"/> limited by default to the production credentials
/// (environment, workload identity and managed identity; <c>AZURE_TOKEN_CREDENTIALS</c> overrides the
/// selection). The resolved credential and endpoint are
/// shared by response storage and resilient-task storage, and the credential is never published to
/// the service collection. Credential settings that are present (in configuration or set by the
/// <c>configureSettings</c> callback) but do not resolve are an error; they are never replaced by
/// the fallback.
/// </para>
/// </summary>
[Experimental("SCME0002")]
public static class ResponsesServerHostExtensions
{
    private const string CredentialSelectionVariable = "AZURE_TOKEN_CREDENTIALS";

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
            IConfigurationSection section = host.Configuration.GetSection(sectionName);

            // The single identity resolved here is used for BOTH response and task storage.
            TokenCredential credential = ResolveCredential(host, section, settings, sectionName);
            Uri projectEndpoint = ResolveEndpoint(section, settings, sectionName);

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
        IHostApplicationBuilder host,
        IConfigurationSection section,
        ResponsesServerSettings settings,
        string sectionName)
    {
        // GetAzureClientSettings resolves CredentialProvider to a TokenCredential (via the built-in
        // AzureCredentialResolver) for token-credential sections; a code-configured CredentialProvider
        // set through configureSettings wins.
        switch (settings.CredentialProvider)
        {
            case TokenCredential credential:
                return credential;

            // Nothing was configured, so use the platform identity. A credential selection that was
            // supplied (by configuration or by configureSettings) but did not resolve, for example a
            // misspelled CredentialSource, is deliberately NOT replaced, so it cannot silently change
            // which identity accesses response storage.
            case null when !HasCredentialSelection(section, settings):
                return CreateFallbackCredential(host, sectionName);

            case null:
                throw new InvalidOperationException(
                    $"The '{sectionName}:Credential' settings did not resolve to a credential " +
                    $"(CredentialSource '{section["Credential:CredentialSource"] ?? settings.Credential?.CredentialSource}'). " +
                    $"Correct the CredentialSource, remove the credential settings to use the platform " +
                    $"identity, or set CredentialProvider via the configureSettings callback.");

            default:
                throw new InvalidOperationException(
                    $"Hosted Foundry storage requires a {nameof(TokenCredential)}; the configured " +
                    $"CredentialProvider is '{settings.CredentialProvider.GetType().FullName}'.");
        }
    }

    // True when the operator selected a credential, either through the configuration section or by
    // setting credential metadata in the configureSettings callback, whether or not it resolved.
    private static bool HasCredentialSelection(
        IConfigurationSection section,
        ResponsesServerSettings settings)
        => section.GetSection("Credential").Exists()
            || !string.IsNullOrEmpty(settings.Credential?.CredentialSource)
            || !string.IsNullOrEmpty(settings.Credential?.Key);

    private static Uri ResolveEndpoint(
        IConfigurationSection section,
        ResponsesServerSettings settings,
        string sectionName)
    {
        if (settings.Endpoint is { } configured)
        {
            return configured;
        }

        // A blank Endpoint is an explicit (if empty) value; do not silently replace it.
        if (section["Endpoint"] is not null)
        {
            throw new InvalidOperationException(
                $"'{sectionName}:Endpoint' is configured but empty. Provide an absolute Foundry project " +
                $"endpoint URI, or remove the setting to use FOUNDRY_PROJECT_ENDPOINT.");
        }

        string? platformEndpoint = FoundryEnvironment.ProjectEndpoint;
        if (string.IsNullOrWhiteSpace(platformEndpoint))
        {
            throw new InvalidOperationException(
                $"A Foundry project endpoint is required for hosted storage. Configure " +
                $"'{sectionName}:Endpoint' or provide the FOUNDRY_PROJECT_ENDPOINT environment variable.");
        }

        if (!Uri.TryCreate(platformEndpoint, UriKind.Absolute, out Uri? endpoint))
        {
            throw new InvalidOperationException(
                "FOUNDRY_PROJECT_ENDPOINT must be an absolute URI.");
        }

        return endpoint;
    }

    private static TokenCredential CreateFallbackCredential(
        IHostApplicationBuilder host,
        string sectionName)
    {
        // AZURE_TOKEN_CREDENTIALS is the operator's explicit credential selection. Honor it with the
        // standard DefaultAzureCredential semantics (including failing fast on an invalid value).
        string? selection = Environment.GetEnvironmentVariable(CredentialSelectionVariable);
        bool operatorSelected = !string.IsNullOrEmpty(selection);

        // A hosted container has no developer tooling. Unless the operator chose otherwise, limit the
        // chain to the production credentials (environment, workload identity, managed identity) so a
        // failure cannot fall through to a developer identity.
        DefaultAzureCredential credential = operatorSelected
            ? new DefaultAzureCredential()
            : new DefaultAzureCredential(new DefaultAzureCredentialOptions
            {
                ExcludeVisualStudioCredential = true,
                ExcludeVisualStudioCodeCredential = true,
                ExcludeAzureCliCredential = true,
                ExcludeAzurePowerShellCredential = true,
                ExcludeAzureDeveloperCliCredential = true,
                ExcludeBrokerCredential = true,
            });

        // The marker only drives a startup log line; the credential itself is not published.
        host.Services.TryAddSingleton(
            new ResponsesHostedCredentialFallback(sectionName, operatorSelected ? selection : null));
        return credential;
    }
}

/// <summary>
/// Records that hosted storage uses the platform fallback credential so startup can log it. It
/// carries no credential and is not a <see cref="TokenCredential"/> service.
/// </summary>
internal sealed class ResponsesHostedCredentialFallback
{
    public ResponsesHostedCredentialFallback(string sectionName, string? operatorSelection)
    {
        SectionName = sectionName;
        OperatorSelection = operatorSelection;
    }

    public string SectionName { get; }

    /// <summary>
    /// The <c>AZURE_TOKEN_CREDENTIALS</c> value when the operator selected the credential chain;
    /// <see langword="null"/> when the production-only default chain is used.
    /// </summary>
    public string? OperatorSelection { get; }
}
