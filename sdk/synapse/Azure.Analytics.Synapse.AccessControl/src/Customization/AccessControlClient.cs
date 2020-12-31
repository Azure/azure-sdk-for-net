// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class AccessControlClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessControlClient"/>.
        /// </summary>
        public AccessControlClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, AccessControlClientOptions.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessControlClient"/>.
        /// </summary>
        public AccessControlClient(Uri endpoint, TokenCredential credential, AccessControlClientOptions options)
            : this(new ClientDiagnostics(options),
                  SynapseClientPipeline.Build(options, credential),
                  endpoint.ToString(),
                  options.VersionString)
        {
        }
    }
}
