// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Insights;

namespace Azure.ResourceManager.Insights
{
    /// <summary> Insights service management client. </summary>
    public partial class InsightsManagementClient
    {
        /// <summary> Initializes a new instance of InsightsManagementClient. </summary>
        /// <param name="subscriptionId"> The Azure subscription Id. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="tokenCredential"> The OAuth token for making client requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public InsightsManagementClient(string subscriptionId, Uri endpoint, TokenCredential tokenCredential, InsightsManagementClientOptions options = null)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            endpoint ??= new Uri("https://management.azure.com");

            options ??= new InsightsManagementClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(tokenCredential, $"{endpoint}/.default"));
            _subscriptionId = subscriptionId;
            _endpoint = endpoint;
        }
    }
}
