// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
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
        /// Azure SDK log forwarding to <see cref="ILogger"/> is enabled once the configured client is created.
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
        /// Azure SDK log forwarding to <see cref="ILogger"/> is disabled by default. It can be enabled by calling the <see cref="AzureEventSourceLogForwarder.Start"/> method.
        /// Alternatively, you can use the <see cref="AddAzureClientsCore(Microsoft.Extensions.DependencyInjection.IServiceCollection, bool)"/> overload
        /// and pass <value>true</value> to enable log forwarding.
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
        /// <param name="enableLogForwarding">Whether to enable Azure SDK log forwarding to <see cref="ILogger"/>. If set to <value>false</value>,
        /// log forwarding can still be enabled by calling the <see cref="AzureEventSourceLogForwarder.Start"/> method. Note that even when setting to <value>true</value>,
        /// you'll need to either inject the <see cref="AzureEventSourceLogForwarder"/> somewhere in your app or retrieve it from the service collection.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AddAzureClientsCore(this IServiceCollection collection, bool enableLogForwarding)
        {
            collection.AddOptions();
            collection.TryAddSingleton<AzureEventSourceLogForwarder>(provider =>
            {
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                var forwarder = new AzureEventSourceLogForwarder(loggerFactory);
                if (enableLogForwarding)
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