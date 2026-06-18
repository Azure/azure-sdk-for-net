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
    /// <summary> Compatibility declaration for the PacketCaptureResource type. </summary>
    public partial class PacketCaptureResource
    {
        /// <summary> Invokes the UpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<PacketCaptureResource>> UpdateAsync(WaitUntil waitUntil, PacketCaptureCreateOrUpdateContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Update compatibility operation. </summary>
        public virtual ArmOperation<PacketCaptureResource> Update(WaitUntil waitUntil, PacketCaptureCreateOrUpdateContent content, CancellationToken cancellationToken) => default;
    }
}
