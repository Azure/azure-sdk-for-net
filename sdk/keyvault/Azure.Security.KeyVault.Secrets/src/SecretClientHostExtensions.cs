// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.Identity;
using Microsoft.Extensions.Hosting;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Extension methods to add <see cref="SecretClient"/> to an <see cref="IHostApplicationBuilder"/>.
    /// </summary>
    [Experimental("SCME0002")]
    public static class SecretClientHostExtensions
    {
        /// <summary>
        /// Adds a singleton <see cref="SecretClient"/> to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="sectionName">The section of <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to use.</param>
        /// <returns>An <see cref="IClientBuilder"/> that can be used to further configure the client.</returns>
        public static IClientBuilder AddSecretClient(
            this IHostApplicationBuilder host,
            string sectionName)
            => host.AddAzureClient<SecretClient, SecretClientSettings>(sectionName);

        /// <summary>
        /// Adds a singleton <see cref="SecretClient"/> to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="sectionName">The section of <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to use.</param>
        /// <param name="configureSettings">Factory method to modify the <see cref="SecretClientSettings"/> after they are created.</param>
        /// <returns>An <see cref="IClientBuilder"/> that can be used to further configure the client.</returns>
        public static IClientBuilder AddSecretClient(
            this IHostApplicationBuilder host,
            string sectionName,
            Action<SecretClientSettings> configureSettings)
            => host.AddAzureClient<SecretClient, SecretClientSettings>(sectionName, configureSettings);

        /// <summary>
        /// Adds a keyed singleton <see cref="SecretClient"/> to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="key">The unique key to register as.</param>
        /// <param name="sectionName">The section of <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to use.</param>
        /// <returns>An <see cref="IClientBuilder"/> that can be used to further configure the client.</returns>
        public static IClientBuilder AddKeyedSecretClient(
            this IHostApplicationBuilder host,
            string key,
            string sectionName)
            => host.AddKeyedAzureClient<SecretClient, SecretClientSettings>(key, sectionName);

        /// <summary>
        /// Adds a keyed singleton <see cref="SecretClient"/> to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="key">The unique key to register as.</param>
        /// <param name="sectionName">The section of <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to use.</param>
        /// <param name="configureSettings">Factory method to modify the <see cref="SecretClientSettings"/> after they are created.</param>
        /// <returns>An <see cref="IClientBuilder"/> that can be used to further configure the client.</returns>
        public static IClientBuilder AddKeyedSecretClient(
            this IHostApplicationBuilder host,
            string key,
            string sectionName,
            Action<SecretClientSettings> configureSettings)
            => host.AddKeyedAzureClient<SecretClient, SecretClientSettings>(key, sectionName, configureSettings);
    }
}
