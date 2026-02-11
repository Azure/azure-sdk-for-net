// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity
{
    /// <summary>
    /// Provides extension methods for <see cref="IConfiguration"/> interface.
    /// </summary>
    [Experimental("SCME0002")]
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
        /// Adds a singleton Azure client of the specified type to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <typeparam name="TClient">The type of Azure client.</typeparam>
        /// <typeparam name="TSettings">The type of <see cref="ClientSettings"/>.</typeparam>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to use.</param>
        public static IHostApplicationBuilder AddAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
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
        public static IHostApplicationBuilder AddAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
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
        public static IHostApplicationBuilder AddKeyedAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
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
        public static IHostApplicationBuilder AddKeyedAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
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
                DefaultAzureCredentialOptions options = new(settings.Credential, config.GetSection("Credential"));
                settings.CredentialProvider = new ConfigurableCredential(options);
            });
            return settings;
        }

        private static void AddDefaultScope(ClientSettings settings)
        {
            settings.PostConfigure(section =>
            {
                // For packages that support both non azure services and azure services we need to set the default
                // scope when the configuration is pointed at the azure endpoint.  OpenAI is currently the only
                // service that falls into this category.
                string endpoint = section["Options:Endpoint"];
                if (endpoint is not null &&
                    endpoint.AsSpan().Contains(".openai.azure.com".AsSpan(), StringComparison.OrdinalIgnoreCase) &&
                    section.GetSection("Credential").Exists())
                {
                    IConfigurationSection scope = settings.Credential.AdditionalProperties.GetSection("Scope");
                    if (!scope.Exists() || scope.Value is null)
                    {
                        scope.Value = "https://cognitiveservices.azure.com/.default";
                    }
                }
            });
        }

        /// <summary>
        /// Registers a credential factory to return a <see cref="TokenCredential"/> to use for the current <see cref="IClientBuilder"/>.
        /// </summary>
        /// <param name="clientBuilder">The <see cref="IClientBuilder"/> to add the credential to.</param>
        public static IHostApplicationBuilder WithAzureCredential(this IClientBuilder clientBuilder)
            => clientBuilder.PostConfigure(settings =>
            {
                AddDefaultScope(settings);
                settings.PostConfigure(config =>
                {
                    DefaultAzureCredentialOptions options = new(settings.Credential, config.GetSection("Credential"));
                    settings.CredentialProvider = new ConfigurableCredential(options);
                });
            });
    }
}
