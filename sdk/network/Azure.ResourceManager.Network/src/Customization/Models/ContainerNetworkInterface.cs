// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    public partial class ContainerNetworkInterface
    {
        // Absent in 1.15.0, but shipped in 1.17.0. Preserve the released subclass constructor signature.
        /// <summary> Initializes a new instance of the ContainerNetworkInterface class. </summary>
        protected ContainerNetworkInterface(bool _) { }
    }
}
