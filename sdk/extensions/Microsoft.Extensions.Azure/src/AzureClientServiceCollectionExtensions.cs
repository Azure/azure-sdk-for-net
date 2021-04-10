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
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/>.</param>
        public static void AddAzureClientsCore(this IServiceCollection collection)
        {
            collection.AddOptions();
            collection.TryAddSingleton<AzureEventSourceLogForwarder>();
            collection.TryAddSingleton<ILoggerFactory, NullLoggerFactory>();
            collection.TryAddSingleton<AzureComponentFactory, AzureComponentFactoryImpl>();
        }
    }
}