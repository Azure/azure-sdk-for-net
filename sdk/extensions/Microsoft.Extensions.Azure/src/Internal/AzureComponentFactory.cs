// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Exposes methods to create various Azure client related types.
    /// </summary>
    public abstract class AzureComponentFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="TokenCredential"/> from the provided <see cref="IConfiguration"/> object or returns a current default.
        /// </summary>
        public abstract TokenCredential CreateTokenCredential(IConfiguration configuration);

        /// <summary>
        /// Creates an instance of a client options type while applying the global and configuration settings to it.
        /// </summary>
        /// <param name="optionsType">Type of the options.</param>
        /// <param name="serviceVersion">The value of ServiceVersion enum to use, null to use the default.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> instance to apply to options.</param>
        /// <returns>A new instance of <paramref name="optionsType"/>.</returns>
        public abstract object CreateClientOptions(Type optionsType, object serviceVersion, IConfiguration configuration);

        /// <summary>
        /// Creates a new client instance using the provided configuration to map constructor parameters from.
        /// Optionally takes a set of client option and credential to use when constructing a client.
        /// </summary>
        /// <param name="clientType"></param>
        /// <param name="configuration">The <see cref="IConfiguration"/> instance to map constructor parameters from.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> object to use if required by constructor, if null no .</param>
        /// <param name="clientOptions">The client </param>
        /// <returns></returns>
        public abstract object CreateClient(Type clientType, IConfiguration configuration, TokenCredential credential, object clientOptions);
    }
}