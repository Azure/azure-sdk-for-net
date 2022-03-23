// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns
{
    /// <summary> Dns service management client. </summary>
    public partial class DnsManagementClient
    {
        /// <summary> Initializes a new instance of DnsManagementClient. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="tokenCredential"> The OAuth token for making client requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public DnsManagementClient(string subscriptionId, Uri endpoint, TokenCredential tokenCredential, DnsManagementClientOptions options = null)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            endpoint ??= new Uri("https://management.azure.com");

            options ??= new DnsManagementClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(tokenCredential, $"{endpoint}/.default"));
            _subscriptionId = subscriptionId;
            _endpoint = endpoint;
        }
    }
}
