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
    /// <summary> Compatibility declaration for the BastionHostResource type. </summary>
    public partial class BastionHostResource
    {
        /// <summary> Invokes the UpdateAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `BastionHostCollection.CreateOrUpdateAsync` instead.", false)]
        public virtual Task<ArmOperation<BastionHostResource>> UpdateAsync(WaitUntil waitUntil, BastionHostData data, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the Update compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `BastionHostCollection.CreateOrUpdate` instead.", false)]
        public virtual ArmOperation<BastionHostResource> Update(WaitUntil waitUntil, BastionHostData data, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
