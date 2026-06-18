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
    /// <summary> Compatibility declaration for the IpamPoolCollection type. </summary>
    public partial class IpamPoolCollection
    {
        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<IpamPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ipamPoolName, IpamPoolData data, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<IpamPoolResource> CreateOrUpdate(WaitUntil waitUntil, string ipamPoolName, IpamPoolData data, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<IpamPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ipamPoolName, IpamPoolData data, string ifMatch, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<IpamPoolResource> CreateOrUpdate(WaitUntil waitUntil, string ipamPoolName, IpamPoolData data, string ifMatch, CancellationToken cancellationToken) => default;
    }
}
