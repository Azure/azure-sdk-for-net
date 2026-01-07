// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity
{
    /// <summary>
    /// .
    /// </summary>
    public static class ClientBuilderExtensions
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="clientBuilder"></param>
        /// <returns></returns>
        public static IHostApplicationBuilder WithAzureCredential(this IClientBuilder clientBuilder)
        {
            clientBuilder.SetCredentialObject(new ConfigurableCredential(new CredentialSettings(clientBuilder.ConfigurationSection.GetSection("Credential"))));
            return clientBuilder;
        }
    }
}
