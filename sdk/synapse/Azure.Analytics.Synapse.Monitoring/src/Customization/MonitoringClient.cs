// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Monitoring
{
    public partial class MonitoringClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonitoringClient"/>.
        /// </summary>
        public MonitoringClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, MonitoringClientOptions.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitoringClient"/>.
        /// </summary>
        public MonitoringClient(Uri endpoint, TokenCredential credential, MonitoringClientOptions options)
            : this(new ClientDiagnostics(options),
                  SynapseClientPipeline.Build(options, credential),
                  endpoint.ToString(),
                  options.VersionString)
        {
        }
    }
}
