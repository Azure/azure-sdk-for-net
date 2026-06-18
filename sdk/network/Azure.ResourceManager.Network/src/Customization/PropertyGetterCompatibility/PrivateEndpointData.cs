// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PrivateEndpointData type. </summary>
    public partial class PrivateEndpointData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.PrivateEndpointIPConfiguration> IPConfigurations { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.PrivateEndpointIPConfiguration>();
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.PrivateEndpointIPVersionType> IPVersionType { get; set; }
    }
}
