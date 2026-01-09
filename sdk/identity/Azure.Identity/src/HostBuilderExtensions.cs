// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity
{
    /// <summary>
    /// Provides extension methods for the <see cref="IHostApplicationBuilder"/> interface.
    /// </summary>
    public static class HostBuilderExtensions
    {
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
            => host.AddAzureClient<TClient, TSettings>(sectionName, default);

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
        {
            host.Services.AddSingleton(sp =>
            {
                TSettings settings = host.Configuration.GetAzureClientSettings<TSettings>(sectionName);
                configureSettings?.Invoke(settings);
                return settings;
            });
            host.Services.AddSingleton(sp => ActivatorUtilities.CreateInstance<TClient>(sp, sp.GetRequiredService<TSettings>()));
            return host;
        }

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
            => host.AddKeyedAzureClient<TClient, TSettings>(key, sectionName, default);

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
        {
            host.Services.AddKeyedSingleton(key, (sp, key) =>
            {
                TSettings settings = host.Configuration.GetAzureClientSettings<TSettings>(sectionName);
                configureSettings?.Invoke(settings);
                return settings;
            });
            host.Services.AddKeyedSingleton(key, (sp, key) => ActivatorUtilities.CreateInstance<TClient>(sp, sp.GetRequiredKeyedService<TSettings>(key)));
            return host;
        }
    }
}
