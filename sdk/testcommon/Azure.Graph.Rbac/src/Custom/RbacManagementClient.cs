// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Graph.Rbac;

namespace Azure.Graph.Rbac
{
    /// <summary> Rbac service management client. </summary>
    public partial class RbacManagementClient
    {
        /// <summary> Initializes a new instance of RbacManagementClient. </summary>
        /// <param name="tenantID"> The tenant ID. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="tokenCredential"> The OAuth token for making client requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantID"/> is null. </exception>
        public RbacManagementClient(string tenantID, Uri endpoint, TokenCredential tokenCredential, RbacManagementClientOptions options = null)
        {
            if (tenantID == null)
            {
                throw new ArgumentNullException(nameof(tenantID));
            }
            endpoint ??= new Uri("https://graph.windows.net");

            options ??= new RbacManagementClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(tokenCredential, $"{endpoint}/.default"));
            _tenantID = tenantID;
            _endpoint = endpoint;
        }
    }
}
