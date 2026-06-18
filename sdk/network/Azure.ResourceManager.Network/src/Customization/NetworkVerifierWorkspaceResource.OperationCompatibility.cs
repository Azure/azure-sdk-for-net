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
    /// <summary> Compatibility declaration for the NetworkVerifierWorkspaceResource type. </summary>
    public partial class NetworkVerifierWorkspaceResource
    {
        /// <summary> Invokes the DeleteAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Delete compatibility operation. </summary>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the DeleteAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Delete compatibility operation. </summary>
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the UpdateAsync compatibility operation. </summary>
        public virtual Task<Response<NetworkVerifierWorkspaceResource>> UpdateAsync(NetworkVerifierWorkspacePatch patch, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Update compatibility operation. </summary>
        public virtual Response<NetworkVerifierWorkspaceResource> Update(NetworkVerifierWorkspacePatch patch, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the UpdateAsync compatibility operation. </summary>
        public virtual Task<Response<NetworkVerifierWorkspaceResource>> UpdateAsync(NetworkVerifierWorkspacePatch patch, string ifMatch, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Update compatibility operation. </summary>
        public virtual Response<NetworkVerifierWorkspaceResource> Update(NetworkVerifierWorkspacePatch patch, string ifMatch, CancellationToken cancellationToken) => default;
    }
}
