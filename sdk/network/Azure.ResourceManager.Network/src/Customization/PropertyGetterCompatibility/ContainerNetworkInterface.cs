// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ContainerNetworkInterface type. </summary>
    public partial class ContainerNetworkInterface
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.ContainerNetworkInterfaceIPConfiguration> IPConfigurations => default;
    }
}
