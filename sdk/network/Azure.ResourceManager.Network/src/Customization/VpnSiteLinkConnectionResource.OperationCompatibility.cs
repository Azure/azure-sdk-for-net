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
    /// <summary> Compatibility declaration for the VpnSiteLinkConnectionResource type. </summary>
    public partial class VpnSiteLinkConnectionResource
    {
        /// <summary> Invokes the GetIkeSasVpnLinkConnectionAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<string>> GetIkeSasVpnLinkConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetIkeSasVpnLinkConnection compatibility operation. </summary>
        public virtual ArmOperation<string> GetIkeSasVpnLinkConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the ResetConnectionVpnLinkConnectionAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> ResetConnectionVpnLinkConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the ResetConnectionVpnLinkConnection compatibility operation. </summary>
        public virtual ArmOperation ResetConnectionVpnLinkConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
