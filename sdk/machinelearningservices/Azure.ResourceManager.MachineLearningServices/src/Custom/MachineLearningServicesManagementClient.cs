// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.MachineLearningServices;

namespace Azure.ResourceManager.MachineLearningServices
{
    /// <summary> MachineLearningServices service management client. </summary>
    public partial class MachineLearningServicesManagementClient
    {
        /// <summary> Initializes a new instance of MachineLearningServicesManagementClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="subscriptionId"> Azure subscription identifier. </param>
        /// <param name="tokenCredential"> The OAuth token for making client requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public MachineLearningServicesManagementClient(Uri endpoint, string subscriptionId, TokenCredential tokenCredential, MachineLearningServicesManagementClientOptions options = null)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            endpoint ??= new Uri("https://management.azure.com");

            options ??= new MachineLearningServicesManagementClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(tokenCredential, $"{endpoint}/.default"));
            _endpoint = endpoint;
            _subscriptionId = subscriptionId;
        }
    }
}
