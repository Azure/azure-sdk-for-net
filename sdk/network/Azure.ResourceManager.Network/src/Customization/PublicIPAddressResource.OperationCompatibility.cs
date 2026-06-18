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
    /// <summary> Compatibility declaration for the PublicIPAddressResource type. </summary>
    public partial class PublicIPAddressResource
    {
        /// <summary> Invokes the DisassociateCloudServiceReservedPublicIPAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<PublicIPAddressResource>> DisassociateCloudServiceReservedPublicIPAsync(WaitUntil waitUntil, DisassociateCloudServicePublicIPContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the DisassociateCloudServiceReservedPublicIP compatibility operation. </summary>
        public virtual ArmOperation<PublicIPAddressResource> DisassociateCloudServiceReservedPublicIP(WaitUntil waitUntil, DisassociateCloudServicePublicIPContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the ReserveCloudServicePublicIPAddressAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<PublicIPAddressResource>> ReserveCloudServicePublicIPAddressAsync(WaitUntil waitUntil, ReserveCloudServicePublicIPAddressContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the ReserveCloudServicePublicIPAddress compatibility operation. </summary>
        public virtual ArmOperation<PublicIPAddressResource> ReserveCloudServicePublicIPAddress(WaitUntil waitUntil, ReserveCloudServicePublicIPAddressContent content, CancellationToken cancellationToken) => default;
    }
}
