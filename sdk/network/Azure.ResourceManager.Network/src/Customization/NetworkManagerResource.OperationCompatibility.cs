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
    /// <summary> Compatibility declaration for the NetworkManagerResource type. </summary>
    public partial class NetworkManagerResource
    {
        /// <summary> Invokes the PostNetworkManagerCommitAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<NetworkManagerCommit>> PostNetworkManagerCommitAsync(WaitUntil waitUntil, NetworkManagerCommit content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the PostNetworkManagerCommit compatibility operation. </summary>
        public virtual ArmOperation<NetworkManagerCommit> PostNetworkManagerCommit(WaitUntil waitUntil, NetworkManagerCommit content, CancellationToken cancellationToken) => default;
    }
}
