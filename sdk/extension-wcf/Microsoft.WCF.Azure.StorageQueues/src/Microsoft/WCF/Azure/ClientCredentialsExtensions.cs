// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.WCF.Azure
{
    /// <summary>
    /// Provides extension methods for working with client credentials in Azure.
    /// </summary>
    public static class ClientCredentialsExtensions
    {
        /// <summary>
        /// Configures the <paramref name="channelFactory"/> to use a new <see cref="AzureClientCredentials"/> instance.
        /// </summary>
        /// <param name="channelFactory">The channel factory.</param>
        /// <returns>The <see cref="AzureClientCredentials"/> instance that was created.</returns>
        public static AzureClientCredentials UseAzureCredentials(this ChannelFactory channelFactory)
        {
            var creds = new AzureClientCredentials();
            var behaviors = channelFactory.Endpoint.EndpointBehaviors as KeyedByTypeCollection<IEndpointBehavior>;
            behaviors.Remove<ClientCredentials>();
            behaviors.Add(creds);
            return creds;
        }

        /// <summary>
        /// Configures the <paramref name="channelFactory"/> to use a new <see cref="AzureClientCredentials"/> instance and allows additional configuration.
        /// </summary>
        /// <param name="channelFactory">The channel factory.</param>
        /// <param name="configure">The configuration action.</param>
        /// <returns>The <see cref="AzureClientCredentials"/> instance that was created.</returns>
        public static AzureClientCredentials UseAzureCredentials(this ChannelFactory channelFactory, Action<AzureClientCredentials> configure)
        {
            var creds = channelFactory.UseAzureCredentials();
            if (configure != null)
            {
                configure(creds);
            }

            return creds;
        }
    }
}
