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
    /// <summary> Compatibility declaration for the ManagementGroupNetworkManagerConnectionCollection type. </summary>
    public partial class ManagementGroupNetworkManagerConnectionCollection
    {
        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ManagementGroupNetworkManagerConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkManagerConnectionName, NetworkManagerConnectionData data, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<ManagementGroupNetworkManagerConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string networkManagerConnectionName, NetworkManagerConnectionData data, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
