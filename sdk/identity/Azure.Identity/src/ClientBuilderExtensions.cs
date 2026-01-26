// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity
{
    /// <summary>
    /// Provides extension methods for the <see cref="IClientBuilder"/> interface.
    /// </summary>
    public static class ClientBuilderExtensions
    {
        /// <summary>
        /// Registers a credential factory to return a <see cref="TokenCredential"/> to use for the current <see cref="IClientBuilder"/>.
        /// </summary>
        /// <param name="clientBuilder">The <see cref="IClientBuilder"/> to add the credential to.</param>
        public static IHostApplicationBuilder WithAzureCredential(this IClientBuilder clientBuilder)
            => clientBuilder.WithCredential(section => new ConfigurableCredential(new CredentialSettings(section.GetSection("Credential"))));
    }
}
