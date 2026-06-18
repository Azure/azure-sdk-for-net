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
    /// <summary> Compatibility declaration for the NetworkGroupResource type. </summary>
    public partial class NetworkGroupResource
    {
        /// <summary> Invokes the UpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<NetworkGroupResource>> UpdateAsync(WaitUntil waitUntil, NetworkGroupData data, string ifMatch, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Update compatibility operation. </summary>
        public virtual ArmOperation<NetworkGroupResource> Update(WaitUntil waitUntil, NetworkGroupData data, string ifMatch, CancellationToken cancellationToken) => default;
    }
}
