﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class RoleAssignmentsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentsClient"/>.
        /// </summary>
        public RoleAssignmentsClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, RoleAssignmentsClientOptions.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignmentsClient"/>.
        /// </summary>
        public RoleAssignmentsClient(Uri endpoint, TokenCredential credential, RoleAssignmentsClientOptions options)
            : this(new ClientDiagnostics(options),
                  SynapseClientPipeline.Build(options, credential),
                  endpoint.ToString(),
                  options.VersionString)
        {
        }
    }
}
