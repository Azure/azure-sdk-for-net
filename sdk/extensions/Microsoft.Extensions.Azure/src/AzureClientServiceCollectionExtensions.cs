// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Azure clients builder extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class AzureClientServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IAzureClientFactory{TClient}"/> and related services to the <see cref="IServiceCollection"/>.
        /// Azure SDK logging is enabled once the configured client is created.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configureClients">An <see cref="AzureClientFactoryBuilder"/> that can be used to configure the client.</param>
        public static void AddAzureClients(this IServiceCollection collection, Action<AzureClientFactoryBuilder> configureClients)
        {
            collection.AddAzureClientsCore();
            configureClients(new AzureClientFactoryBuilder(collection));
        }

        /// <summary>
        /// Adds the minimum essential Azure SDK interop services like <see cref="AzureEventSourceLogForwarder"/> and <see cref="AzureComponentFactory"/> to the specified <see cref="IServiceCollection"/> without registering any client types.
        /// Azure SDK logging will not be enabled by default, but can be enabled by calling the <see cref="AzureEventSourceLogForwarder.Start"/> method.
        /// Alternatively, you can use the <see cref="AddAzureClientsCore(Microsoft.Extensions.DependencyInjection.IServiceCollection, bool)"/> overload
        /// and pass <value>true</value> to enable logging.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/>.</param>
        public static void AddAzureClientsCore(this IServiceCollection collection)
        {
            collection.AddAzureClientsCore(false);
        }

        /// <summary>
        /// Adds the minimum essential Azure SDK interop services like <see cref="AzureEventSourceLogForwarder"/> and <see cref="AzureComponentFactory"/> to the specified <see cref="IServiceCollection"/> without registering any client types.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/>.</param>
        /// <param name="enableLogging">Whether or not to enable Azure SDK logging. Even if this is set to <value>false</value>, logging can be enabled
        /// by calling the <see cref="AzureEventSourceLogForwarder.Start"/> method.</param>
        public static void AddAzureClientsCore(this IServiceCollection collection, bool enableLogging)
        {
            collection.AddOptions();
            collection.TryAddSingleton<AzureEventSourceLogForwarder>(provider =>
            {
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                var forwarder = new AzureEventSourceLogForwarder(loggerFactory);
                if (enableLogging)
                {
                    forwarder.Start();
                }

                return forwarder;
            });
            collection.TryAddSingleton<ILoggerFactory, NullLoggerFactory>();
            collection.TryAddSingleton<AzureComponentFactory, AzureComponentFactoryImpl>();
        }
    }
}