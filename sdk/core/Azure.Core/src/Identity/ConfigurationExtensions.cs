// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity
{
    /// <summary>
    /// Provides extension methods for <see cref="IConfiguration"/> interface.
    /// </summary>
    [Experimental("SCME0002")]
    [UnsupportedOSPlatform("browser")]
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Creates an instance of <typeparamref name="T"/> and sets its properties from the specified <see cref="IConfiguration"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ClientSettings"/> to create.</typeparam>
        /// <param name="configuration">The <see cref="IConfiguration"/> to bind the properties of <typeparamref name="T"/> from.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to bind from.</param>
        public static T GetAzureClientSettings<T>(this IConfiguration configuration, string sectionName)
            where T : ClientSettings, new()
            => configuration.GetClientSettings<T>(sectionName).WithAzureCredential();

        /// <summary>
        /// Creates an instance of <typeparamref name="T"/> and sets its properties from the specified <see cref="IConfiguration"/>.
        /// The <see cref="ClientSettings.CredentialProvider"/> is resolved via the supplied
        /// <see cref="CredentialResolver"/> chain together with a built-in <see cref="AzureCredentialResolver"/>
        /// appended to the end of the chain (so caller-supplied resolvers take precedence).
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ClientSettings"/> to create.</typeparam>
        /// <param name="configuration">The <see cref="IConfiguration"/> to bind the properties of <typeparamref name="T"/> from.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to bind from.</param>
        /// <param name="resolvers">Caller-supplied resolvers, evaluated in order before the built-in
        /// <see cref="AzureCredentialResolver"/> is consulted.</param>
        public static T GetAzureClientSettings<T>(
            this IConfiguration configuration,
            string sectionName,
            params CredentialResolver[] resolvers)
            where T : ClientSettings, new()
        {
            CredentialResolver[] combined = [.. resolvers ?? [], AzureCredentialResolver.Instance];

            // Apply the AzureOpenAI default-scope quirk through the credential-section override
            // hook so the resolver sees the modified section, since the credential is materialized
            // synchronously by GetClientSettings.
            string endpoint = configuration.GetSection(sectionName)["Options:Endpoint"];
            if (IsAzureOpenAIEndpoint(endpoint))
            {
                return configuration.GetClientSettings<T>(sectionName, combined, ApplyAzureOpenAIDefaultScope);
            }

            return configuration.GetClientSettings<T>(sectionName, combined);
        }

        /// <summary>
        /// Creates an instance of <typeparamref name="T"/> from the named configuration section,
        /// applying <paramref name="configureOverrides"/> to the credential section before resolution.
        /// The <see cref="ClientSettings.CredentialProvider"/> is resolved via the supplied
        /// <see cref="CredentialResolver"/> chain together with a built-in <see cref="AzureCredentialResolver"/>
        /// appended to the end of the chain (so caller-supplied resolvers take precedence).
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ClientSettings"/> to create.</typeparam>
        /// <param name="configuration">The <see cref="IConfiguration"/> to bind the properties of <typeparamref name="T"/> from.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to bind from.</param>
        /// <param name="resolvers">Caller-supplied resolvers, evaluated in order before the built-in
        /// <see cref="AzureCredentialResolver"/> is consulted.</param>
        /// <param name="configureOverrides">Callback invoked against a writable overlay of the
        /// credential section, allowing properties to be added or overridden before resolution.
        /// The Azure OpenAI default-scope quirk is applied first when applicable, so callers may
        /// override it if needed.</param>
        public static T GetAzureClientSettings<T>(
            this IConfiguration configuration,
            string sectionName,
            IEnumerable<CredentialResolver> resolvers,
            Action<IConfigurationSection> configureOverrides)
            where T : ClientSettings, new()
        {
            CredentialResolver[] combined = [.. resolvers ?? [], AzureCredentialResolver.Instance];

            string endpoint = configuration.GetSection(sectionName)["Options:Endpoint"];
            Action<IConfigurationSection> effectiveOverrides = configureOverrides;
            if (IsAzureOpenAIEndpoint(endpoint))
            {
                // Apply the AzureOpenAI default-scope quirk first, then the caller's overrides
                // so callers can intentionally override our default if needed.
                effectiveOverrides = section =>
                {
                    ApplyAzureOpenAIDefaultScope(section);
                    configureOverrides?.Invoke(section);
                };
            }

            return configuration.GetClientSettings<T>(sectionName, combined, effectiveOverrides);
        }

        /// <summary>
        /// Resolves a <see cref="TokenCredential"/> for the named credential section using a built-in
        /// <see cref="AzureCredentialResolver"/>. Returns <see langword="null"/> when no
        /// credential is configured. Never throws.
        /// </summary>
        /// <param name="configuration">The configuration to resolve from.</param>
        /// <param name="sectionName">The credential section name (treated as the credential
        /// section itself, not a parent client section).</param>
        public static TokenCredential GetAzureCredential(this IConfiguration configuration, string sectionName)
            => configuration.GetAzureCredential(sectionName, Array.Empty<CredentialResolver>());

        /// <summary>
        /// Resolves a <see cref="TokenCredential"/> for the named credential section. Caller-supplied
        /// <paramref name="resolvers"/> are evaluated in order; a built-in
        /// <see cref="AzureCredentialResolver"/> is appended to the chain so it serves as a
        /// fallback. Returns <see langword="null"/> when no resolver claims the section. Never throws.
        /// </summary>
        /// <param name="configuration">The configuration to resolve from.</param>
        /// <param name="sectionName">The credential section name.</param>
        /// <param name="resolvers">Caller-supplied resolvers evaluated before the built-in resolver.</param>
        public static TokenCredential GetAzureCredential(
            this IConfiguration configuration,
            string sectionName,
            params CredentialResolver[] resolvers)
            => configuration.GetCredential(sectionName, [.. resolvers ?? [], AzureCredentialResolver.Instance]) as TokenCredential;

        /// <summary>
        /// Resolves a <see cref="TokenCredential"/> for the named credential section, applying
        /// <paramref name="configureOverrides"/> to the credential section before resolving.
        /// Caller-supplied <paramref name="resolvers"/> are evaluated in order; a built-in
        /// <see cref="AzureCredentialResolver"/> is appended to the chain so it serves as a
        /// fallback. Returns <see langword="null"/> when no resolver claims the section. Never throws.
        /// </summary>
        public static TokenCredential GetAzureCredential(
            this IConfiguration configuration,
            string sectionName,
            IEnumerable<CredentialResolver> resolvers,
            Action<IConfigurationSection> configureOverrides)
            => configuration.GetCredential(sectionName, [.. resolvers ?? [], AzureCredentialResolver.Instance], configureOverrides) as TokenCredential;

        /// <summary>
        /// Registers <see cref="AzureCredentialResolver"/> in the service collection.
        /// Idempotent — repeated calls do not produce duplicate registrations.
        /// </summary>
        /// <param name="services">The service collection to register on.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> is null.</exception>
        public static IServiceCollection AddAzureCredentialResolver(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddCredentialResolver<AzureCredentialResolver>();
        }

        /// <summary>
        /// Registers <see cref="AzureCredentialResolver"/> on the host's service collection.
        /// Idempotent — repeated calls do not produce duplicate registrations.
        /// </summary>
        /// <param name="builder">The host builder to register on.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="builder"/> is null.</exception>
        public static IHostApplicationBuilder AddAzureCredentialResolver(this IHostApplicationBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.AddCredentialResolver<AzureCredentialResolver>();
        }

        private static bool IsAzureOpenAIEndpoint(string endpoint)
            => endpoint is not null
                && endpoint.AsSpan().Contains(".openai.azure.com".AsSpan(), StringComparison.OrdinalIgnoreCase);

        private static void ApplyAzureOpenAIDefaultScope(IConfigurationSection credentialSection)
        {
            // For packages that support both non-Azure services and Azure services we need to set
            // the default scope when the configuration is pointed at the Azure endpoint. OpenAI is
            // currently the only service that falls into this category. Mirrors AddDefaultScope
            // applied by WithAzureCredential, but operates on the credential section directly so
            // the resolver picks it up. SCM 1.12.0+ reads Scope at the root of the credential
            // section (with AdditionalProperties:Scope as a fallback), so we write the canonical
            // root location here.
            IConfigurationSection scope = credentialSection.GetSection("Scope");
            if (!scope.Exists() || scope.Value is null)
            {
                scope.Value = "https://cognitiveservices.azure.com/.default";
            }
        }

        /// <summary>
        /// Adds a singleton Azure client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <typeparam name="TClient">The type of Azure client.</typeparam>
        /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
        public static IClientBuilder AddAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
            this IHostApplicationBuilder host,
            string sectionName)
                where TSettings : ClientSettings, new()
                where TClient : class
            => host.AddClient<TClient, TSettings>(sectionName).WithAzureCredential();

        /// <summary>
        /// Adds a singleton Azure client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <typeparam name="TClient">The type of Azure client.</typeparam>
        /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
        /// <param name="configureSettings">Factory method to modify the <typeparamref name="TSettings"/> after they are created.</param>
        public static IClientBuilder AddAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
            this IHostApplicationBuilder host,
            string sectionName,
            Action<TSettings> configureSettings)
                where TSettings : ClientSettings, new()
                where TClient : class
            => host.AddClient<TClient, TSettings>(sectionName, configureSettings).WithAzureCredential();

        /// <summary>
        /// Adds a keyed singleton Azure client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <typeparam name="TClient">The type of Azure client.</typeparam>
        /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="key">The unique key to register as.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
        public static IClientBuilder AddKeyedAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
            this IHostApplicationBuilder host,
            string key,
            string sectionName)
                where TSettings : ClientSettings, new()
                where TClient : class
            => host.AddKeyedClient<TClient, TSettings>(key, sectionName).WithAzureCredential();

        /// <summary>
        /// Adds a keyed singleton Azure client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <typeparam name="TClient">The type of Azure client.</typeparam>
        /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="key">The unique key to register as.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
        /// <param name="configureSettings">Factory method to modify the <typeparamref name="TSettings"/> after they are created.</param>
        public static IClientBuilder AddKeyedAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
            this IHostApplicationBuilder host,
            string key,
            string sectionName,
            Action<TSettings> configureSettings)
                where TSettings : ClientSettings, new()
                where TClient : class
            => host.AddKeyedClient<TClient, TSettings>(key, sectionName, configureSettings).WithAzureCredential();

        /// <summary>
        /// Sets the <see cref="ClientSettings.CredentialProvider"/> to an instance of <see cref="TokenCredential"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ClientSettings"/>.</typeparam>
        /// <param name="settings">The <see cref="ClientSettings"/> instance.</param>
        public static T WithAzureCredential<T>(this T settings)
            where T : ClientSettings
        {
            if (settings.Credential is null)
            {
                throw new InvalidOperationException("Credential settings must be provided to use Azure Credential.");
            }

            AddDefaultScope(settings);

            settings.PostConfigure(config =>
            {
                IConfigurationSection credentialSection = config.GetSection("Credential");
                settings.CredentialProvider = ConfigurableCredentialCache.GetOrAdd(credentialSection, () =>
                {
                    DefaultAzureCredentialOptions options = new(settings.Credential, credentialSection);
                    return new ConfigurableCredential(options);
                });
            });
            return settings;
        }

        private static void AddDefaultScope(ClientSettings settings)
        {
            settings.PostConfigure(section =>
            {
                // For packages that support both non azure services and azure services we need to set the default
                // scope when the configuration is pointed at the azure endpoint.  OpenAI is currently the only
                // service that falls into this category. Writes to Credential:Scope at the root of the credential
                // section — SCM 1.12.0+ reads from the root and falls back to AdditionalProperties:Scope, so this
                // is the canonical write location going forward.
                string endpoint = section["Options:Endpoint"];
                if (endpoint is not null &&
                    endpoint.AsSpan().Contains(".openai.azure.com".AsSpan(), StringComparison.OrdinalIgnoreCase) &&
                    section.GetSection("Credential").Exists())
                {
                    IConfigurationSection scope = section.GetSection("Credential:Scope");
                    if (!scope.Exists() || scope.Value is null)
                    {
                        scope.Value = "https://cognitiveservices.azure.com/.default";
                    }
                }
            });
        }

        /// <summary>
        /// Registers a credential factory to return a <see cref="TokenCredential"/> to use for the current <see cref="IClientBuilder"/>.
        /// If the same credential configuration has already been registered, the existing credential instance is reused.
        /// </summary>
        /// <param name="clientBuilder">The <see cref="IClientBuilder"/> to add the credential to.</param>
        public static IClientBuilder WithAzureCredential(this IClientBuilder clientBuilder)
        {
            clientBuilder.PostConfigure(settings =>
            {
                AddDefaultScope(settings);
                settings.PostConfigure(config =>
                {
                    IConfigurationSection credentialSection = config.GetSection("Credential");
                    settings.CredentialProvider = ConfigurableCredentialCache.GetOrAdd(credentialSection, () =>
                    {
                        DefaultAzureCredentialOptions options = new(settings.Credential, credentialSection);
                        return new ConfigurableCredential(options);
                    });
                });
            });
            return clientBuilder;
        }
    }
}
