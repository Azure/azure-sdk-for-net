// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class RoleDefinitionsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDefinitionsClient"/>.
        /// </summary>
        public RoleDefinitionsClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, RoleDefinitionsClientOptions.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDefinitionsClient"/>.
        /// </summary>
        public RoleDefinitionsClient(Uri endpoint, TokenCredential credential, RoleDefinitionsClientOptions options)
            : this(new ClientDiagnostics(options),
                  SynapseClientPipeline.Build(options, credential),
                  endpoint.ToString(),
                  options.VersionString)
        {
        }
    }
}
