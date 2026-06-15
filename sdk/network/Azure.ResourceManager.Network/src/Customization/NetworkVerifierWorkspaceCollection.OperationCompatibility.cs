// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVerifierWorkspaceCollection
    {
        public virtual Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, string ifMatch, CancellationToken cancellationToken) => default;
    }
}
