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
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            => configuration.GetAzureClientSettings<T>(sectionName, Array.Empty<CredentialResolver>());

        /// <summary>
        /// Creates an instance of <typeparamref name="T"/> and sets its properties from the specified <see cref="IConfiguration"/>.
        /// The bound settings' <see cref="CredentialSettings.TokenProvider"/> is resolved via the supplied
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

            ApplyAzureOpenAIDefaultScopeIfNeeded(configuration, sectionName);

            return configuration.GetClientSettings<T>(sectionName, combined);
        }

        /// <summary>
        /// Creates an instance of <typeparamref name="T"/> from the named configuration section,
        /// applying <paramref name="configureOverrides"/> to the credential section before resolution.
        /// The bound settings' <see cref="CredentialSettings.TokenProvider"/> is resolved via the supplied
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

            ApplyAzureOpenAIDefaultScopeIfNeeded(configuration, sectionName);

            return configuration.GetClientSettings<T>(sectionName, combined, configureOverrides);
        }

        /// <summary>
        /// Returns the <see cref="CredentialSettings"/> bound from the named credential
        /// section, with <see cref="CredentialSettings.TokenProvider"/> populated by the
        /// built-in <see cref="AzureCredentialResolver"/> when it claims the section.
        /// </summary>
        /// <remarks>
        /// For token-credential sections the returned settings' <see cref="CredentialSettings.TokenProvider"/>
        /// is a <see cref="TokenCredential"/>. For inline ApiKey sections <see cref="CredentialSettings.Key"/>
        /// is populated and <see cref="CredentialSettings.TokenProvider"/> is <see langword="null"/>,
        /// letting callers dispatch on either shape without binding a <see cref="ClientSettings"/>.
        /// Returns <see langword="null"/> only when the named section does not exist. Never throws.
        /// </remarks>
        /// <param name="configuration">The configuration to resolve from.</param>
        /// <param name="sectionName">The credential section name (treated as the credential
        /// section itself, not a parent client section).</param>
        public static CredentialSettings GetAzureCredentialSettings(this IConfiguration configuration, string sectionName)
            => configuration.GetAzureCredentialSettings(sectionName, Array.Empty<CredentialResolver>());

        /// <summary>
        /// Returns the <see cref="CredentialSettings"/> bound from the named credential section.
        /// Caller-supplied <paramref name="resolvers"/> are evaluated in order; the built-in
        /// <see cref="AzureCredentialResolver"/> is appended to the chain as a fallback. The
        /// first resolver to claim the section populates <see cref="CredentialSettings.TokenProvider"/>.
        /// </summary>
        /// <remarks>
        /// When no resolver claims the section (for example, an inline ApiKey section, where the
        /// Azure resolver intentionally defers), the returned settings still expose the bound
        /// <see cref="CredentialSettings.Key"/>, <see cref="CredentialSettings.CredentialSource"/>,
        /// and <see cref="CredentialSettings.AdditionalProperties"/>. Returns <see langword="null"/>
        /// only when the named section does not exist. Never throws.
        /// </remarks>
        /// <param name="configuration">The configuration to resolve from.</param>
        /// <param name="sectionName">The credential section name.</param>
        /// <param name="resolvers">Caller-supplied resolvers evaluated before the built-in resolver.</param>
        public static CredentialSettings GetAzureCredentialSettings(
            this IConfiguration configuration,
            string sectionName,
            params CredentialResolver[] resolvers)
            => configuration.GetCredentialSettings(sectionName, [.. resolvers ?? [], AzureCredentialResolver.Instance]);

        /// <summary>
        /// Returns the <see cref="CredentialSettings"/> bound from the named credential section,
        /// applying <paramref name="configureOverrides"/> to the credential section before resolving.
        /// Caller-supplied <paramref name="resolvers"/> are evaluated in order; the built-in
        /// <see cref="AzureCredentialResolver"/> is appended to the chain as a fallback.
        /// </summary>
        /// <remarks>
        /// The returned settings reflect the post-overlay merged view for
        /// <see cref="CredentialSettings.Key"/>, <see cref="CredentialSettings.CredentialSource"/>,
        /// <see cref="CredentialSettings.AdditionalProperties"/>, and the
        /// <see cref="CredentialSettings.this[string]"/> indexer. Returns <see langword="null"/>
        /// only when the named section does not exist. Never throws.
        /// </remarks>
        public static CredentialSettings GetAzureCredentialSettings(
            this IConfiguration configuration,
            string sectionName,
            IEnumerable<CredentialResolver> resolvers,
            Action<IConfigurationSection> configureOverrides)
            => configuration.GetCredentialSettings(sectionName, [.. resolvers ?? [], AzureCredentialResolver.Instance], configureOverrides);

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

            // Register the static singleton instance so DI and the standalone
            // helpers (which use AzureCredentialResolver.Instance directly) share
            // the same resolver identity. SCM's CredentialCache keys entries by
            // (sectionHash, resolver reference), so sharing the instance lets both
            // paths reuse cached credentials when their bound sections are
            // content-identical. TryAddEnumerable dedupes by implementation type.
            services.TryAddEnumerable(ServiceDescriptor.Singleton<CredentialResolver>(AzureCredentialResolver.Instance));
            return services;
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

            builder.Services.AddAzureCredentialResolver();
            return builder;
        }

        private static bool IsAzureOpenAIEndpoint(string endpoint)
            => endpoint is not null
                && endpoint.AsSpan().Contains(".openai.azure.com".AsSpan(), StringComparison.OrdinalIgnoreCase);

        // Writes the AzureOpenAI default scope directly to the original credential
        // section in IConfiguration so the scope is visible to every consumer of
        // the same section. Skips when the configured endpoint is not an
        // AzureOpenAI endpoint or when the Credential section is absent — we
        // never materialize a Credential section just to attach a scope.
        private static void ApplyAzureOpenAIDefaultScopeIfNeeded(IConfiguration configuration, string sectionName)
        {
            string endpoint = configuration.GetSection(sectionName)["Options:Endpoint"];
            if (!IsAzureOpenAIEndpoint(endpoint))
            {
                return;
            }

            IConfigurationSection credentialSection = configuration.GetSection($"{sectionName}:Credential");
            if (!credentialSection.Exists())
            {
                return;
            }

            ApplyAzureOpenAIDefaultScope(credentialSection);
        }

        private static void ApplyAzureOpenAIDefaultScope(IConfigurationSection credentialSection)
        {
            // For packages that support both non-Azure services and Azure services we need to set
            // the default scope when the configuration is pointed at the Azure endpoint. OpenAI is
            // currently the only service that falls into this category. Scope is written at the root
            // of the credential section, which is where SCM reads it from.
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
            => AddAzureClientCore<TClient, TSettings>(host, sectionName, host.AddClient<TClient, TSettings>(sectionName));

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
            => AddAzureClientCore<TClient, TSettings>(host, sectionName, host.AddClient<TClient, TSettings>(sectionName, configureSettings));

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
            => AddAzureClientCore<TClient, TSettings>(host, sectionName, host.AddKeyedClient<TClient, TSettings>(key, sectionName));

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
            => AddAzureClientCore<TClient, TSettings>(host, sectionName, host.AddKeyedClient<TClient, TSettings>(key, sectionName, configureSettings));

        // Centralizes the Azure-flavored DI setup: registers the static
        // AzureCredentialResolver.Instance and (when the section's endpoint
        // matches the AzureOpenAI default-scope quirk) writes the default
        // scope directly to the credential section so subsequent reads of
        // the source configuration are consistent with the resolved credential.
        // AddAzureCredentialResolver is idempotent.
        private static IClientBuilder AddAzureClientCore<TClient, TSettings>(
            IHostApplicationBuilder host,
            string sectionName,
            IClientBuilder builder)
                where TSettings : ClientSettings, new()
                where TClient : class
        {
            host.AddAzureCredentialResolver();
            ApplyAzureOpenAIDefaultScopeIfNeeded(host.Configuration, sectionName);
            return builder;
        }
    }
}
