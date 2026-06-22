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
    /// <summary> Compatibility declaration for the ManagementGroupNetworkManagerConnectionResource type. </summary>
    public partial class ManagementGroupNetworkManagerConnectionResource
    {
        /// <summary> Invokes the UpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ManagementGroupNetworkManagerConnectionResource>> UpdateAsync(WaitUntil waitUntil, NetworkManagerConnectionData data, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the Update compatibility operation. </summary>
        public virtual ArmOperation<ManagementGroupNetworkManagerConnectionResource> Update(WaitUntil waitUntil, NetworkManagerConnectionData data, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
