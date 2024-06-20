// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Extensions
{
    /// <summary>
    /// Abstraction for registering Azure clients in dependency injection containers.
    /// </summary>
    public interface IAzureClientFactoryBuilder
    {
        /// <summary>
        /// Registers a client in the dependency injection container using the factory to create a client instance.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The client options type used the client.</typeparam>
        /// <param name="clientFactory">The factory, that given the instance of options, returns a client instance.</param>
        /// <returns><see cref="IAzureClientBuilder{TClient,TOptions}"/> that allows customizing the client registration.</returns>
        IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(Func<TOptions, TClient> clientFactory) where TOptions : class;
    }
}
