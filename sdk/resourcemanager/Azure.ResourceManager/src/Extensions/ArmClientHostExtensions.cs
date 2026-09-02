// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.Identity;
using Microsoft.Extensions.Hosting;

namespace Azure.ResourceManager
{
    /// <summary>
    /// Extension methods to add <see cref="ArmClient"/> to an <see cref="IHostApplicationBuilder"/>.
    /// </summary>
    [Experimental("SCME0002")]
    public static class ArmClientHostExtensions
    {
        /// <summary>
        /// Adds a singleton <see cref="ArmClient"/> to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="sectionName">The section of <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to use.</param>
        /// <returns>An <see cref="IClientBuilder"/> that can be used to further configure the client.</returns>
        public static IClientBuilder AddArmClient(
            this IHostApplicationBuilder host,
            string sectionName)
            => host.AddAzureClient<ArmClient, ArmClientSettings>(sectionName);

        /// <summary>
        /// Adds a singleton <see cref="ArmClient"/> to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="sectionName">The section of <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to use.</param>
        /// <param name="configureSettings">Factory method to modify the <see cref="ArmClientSettings"/> after they are created.</param>
        /// <returns>An <see cref="IClientBuilder"/> that can be used to further configure the client.</returns>
        public static IClientBuilder AddArmClient(
            this IHostApplicationBuilder host,
            string sectionName,
            Action<ArmClientSettings> configureSettings)
            => host.AddAzureClient<ArmClient, ArmClientSettings>(sectionName, configureSettings);

        /// <summary>
        /// Adds a keyed singleton <see cref="ArmClient"/> to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="key">The unique key to register as.</param>
        /// <param name="sectionName">The section of <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to use.</param>
        /// <returns>An <see cref="IClientBuilder"/> that can be used to further configure the client.</returns>
        public static IClientBuilder AddKeyedArmClient(
            this IHostApplicationBuilder host,
            string key,
            string sectionName)
            => host.AddKeyedAzureClient<ArmClient, ArmClientSettings>(key, sectionName);

        /// <summary>
        /// Adds a keyed singleton <see cref="ArmClient"/> to the <see cref="IHostApplicationBuilder"/>'s service collection.
        /// </summary>
        /// <param name="host">The <see cref="IHostApplicationBuilder"/> to add to.</param>
        /// <param name="key">The unique key to register as.</param>
        /// <param name="sectionName">The section of <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to use.</param>
        /// <param name="configureSettings">Factory method to modify the <see cref="ArmClientSettings"/> after they are created.</param>
        /// <returns>An <see cref="IClientBuilder"/> that can be used to further configure the client.</returns>
        public static IClientBuilder AddKeyedArmClient(
            this IHostApplicationBuilder host,
            string key,
            string sectionName,
            Action<ArmClientSettings> configureSettings)
            => host.AddKeyedAzureClient<ArmClient, ArmClientSettings>(key, sectionName, configureSettings);
    }
}
