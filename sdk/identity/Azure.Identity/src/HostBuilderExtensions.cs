// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
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
    }
}
