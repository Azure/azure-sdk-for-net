// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints
{
    public partial class ManagedPrivateEndpointsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedPrivateEndpointsClient"/>.
        /// </summary>
        public ManagedPrivateEndpointsClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, ManagedPrivateEndpointsClientOptions.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedPrivateEndpointsClient"/>.
        /// </summary>
        public ManagedPrivateEndpointsClient(Uri endpoint, TokenCredential credential, ManagedPrivateEndpointsClientOptions options)
            : this(new ClientDiagnostics(options),
                  SynapseClientPipeline.Build(options, credential),
                  endpoint.ToString(),
                  options.VersionString)
        {
        }
    }
}
