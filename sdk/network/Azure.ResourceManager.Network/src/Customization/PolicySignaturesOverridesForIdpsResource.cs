// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PolicySignaturesOverridesForIdpsResource type. </summary>
    public partial class PolicySignaturesOverridesForIdpsResource
    {
        /// <summary> Invokes the Update compatibility operation. </summary>
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.PolicySignaturesOverridesForIdpsResource> Update(global::Azure.ResourceManager.Network.PolicySignaturesOverridesForIdpsData p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the UpdateAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.PolicySignaturesOverridesForIdpsResource>> UpdateAsync(global::Azure.ResourceManager.Network.PolicySignaturesOverridesForIdpsData p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
