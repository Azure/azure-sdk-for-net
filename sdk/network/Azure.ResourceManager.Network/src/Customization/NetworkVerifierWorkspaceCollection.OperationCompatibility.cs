// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
    /// <summary> Compatibility declaration for the NetworkVerifierWorkspaceCollection type. </summary>
    public partial class NetworkVerifierWorkspaceCollection
    {
        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, string ifMatch, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, string ifMatch, CancellationToken cancellationToken) => default;
    }
}
