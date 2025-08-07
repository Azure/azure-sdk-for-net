// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Extensions
{
    /// <summary>
    /// Abstraction for registering Azure clients that require <see cref="TokenCredential"/> in dependency injection containers.
    /// </summary>
    public interface IAzureClientFactoryBuilderWithCredential
    {
        /// <summary>
        /// Registers a client in dependency injection container the using the factory to create a client instance.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The client options type used the client.</typeparam>
        /// <param name="clientFactory">The factory, that given the instance of options and credential, returns a client instance.</param>
        /// <param name="requiresCredential">Specifies whether the credential is optional (client supports anonymous authentication).</param>
        /// <returns><see cref="IAzureClientBuilder{TClient,TOptions}"/> that allows customizing the client registration.</returns>
        IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(Func<TOptions, TokenCredential, TClient> clientFactory, bool requiresCredential = true) where TOptions : class;
    }
}
