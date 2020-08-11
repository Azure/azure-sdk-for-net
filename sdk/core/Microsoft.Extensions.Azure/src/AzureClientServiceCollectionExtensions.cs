// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using System;

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
            configureClients(new AzureClientFactoryBuilder(collection));
        }
    }
}