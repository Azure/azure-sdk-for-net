// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity
{
    /// <summary>
    /// .
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// .
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="host"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static IHostApplicationBuilder AddAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
            this IHostApplicationBuilder host,
            string sectionName)
                where TSettings : ClientSettings, new()
                where TClient : class
            => host.AddAzureClient<TClient, TSettings>(sectionName, default);

        /// <summary>
        /// .
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="host"></param>
        /// <param name="sectionName"></param>
        /// <param name="configureSettings"></param>
        /// <returns></returns>
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
        /// .
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="host"></param>
        /// <param name="key"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static IHostApplicationBuilder AddKeyedAzureClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, TSettings>(
            this IHostApplicationBuilder host,
            string key,
            string sectionName)
                where TSettings : ClientSettings, new()
                where TClient : class
            => host.AddKeyedAzureClient<TClient, TSettings>(key, sectionName, default);

        /// <summary>
        /// .
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="host"></param>
        /// <param name="key"></param>
        /// <param name="sectionName"></param>
        /// <param name="configureSettings"></param>
        /// <returns></returns>
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
