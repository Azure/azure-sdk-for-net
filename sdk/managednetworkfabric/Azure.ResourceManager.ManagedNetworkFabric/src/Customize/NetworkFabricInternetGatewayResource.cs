// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricInternetGatewayResource
    {
        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkFabricInternetGatewayPatchContent, CancellationToken) instead.")]
        public virtual Task<ArmOperation<NetworkFabricInternetGatewayResource>> UpdateAsync(WaitUntil waitUntil, NetworkFabricInternetGatewayPatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkFabricInternetGatewayPatchContent, CancellationToken) instead.");
        }

        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkFabricInternetGatewayPatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkFabricInternetGatewayResource> Update(WaitUntil waitUntil, NetworkFabricInternetGatewayPatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkFabricInternetGatewayPatchContent, CancellationToken) instead.");
        }
    }
}
