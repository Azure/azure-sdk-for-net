// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.ResourceManager
{
    /// <summary>
    /// .
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="host"></param>
        /// <param name="key"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static IHostBuilder AddKeyedArmClient(this IHostBuilder host, string key, string sectionName)
        {
            host.ConfigureServices((context, services) =>
            {
                IConfigurationSection section = context.Configuration.GetSection(sectionName);
                services.AddKeyedSingleton(key, (sp, key) => CreateArmClient(sp, section, null));
            });
            return host;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="host"></param>
        /// <param name="key"></param>
        /// <param name="sectionName"></param>
        /// <param name="configureOptions"></param>
        /// <returns></returns>
        public static IHostBuilder AddKeyedArmClient(this IHostBuilder host, string key, string sectionName, Action<ArmClientOptions> configureOptions)
        {
            host.ConfigureServices((context, services) =>
            {
                IConfigurationSection section = context.Configuration.GetSection(sectionName);
                services.AddKeyedSingleton(key, (sp, key) => CreateArmClient(sp, section, configureOptions));
            });
            return host;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="host"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static IHostBuilder AddArmClient(this IHostBuilder host, string sectionName)
        {
            host.ConfigureServices((context, services) =>
            {
                IConfigurationSection section = context.Configuration.GetSection(sectionName);
                services.AddSingleton(sp => CreateArmClient(sp, section, null));
            });
            return host;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="host"></param>
        /// <param name="sectionName"></param>
        /// <param name="configureOptions"></param>
        /// <returns></returns>
        public static IHostBuilder AddArmClient(this IHostBuilder host, string sectionName, Action<ArmClientOptions> configureOptions)
        {
            host.ConfigureServices((context, services) =>
            {
                IConfigurationSection section = context.Configuration.GetSection(sectionName);
                services.AddSingleton(sp => CreateArmClient(sp, section, configureOptions));
            });
            return host;
        }

        private static ArmClient CreateArmClient(IServiceProvider serviceProvider, IConfigurationSection section, Action<ArmClientOptions> configureOptions)
        {
            return new(ArmSettings.Create(serviceProvider, section, configureOptions));
        }
    }
}
