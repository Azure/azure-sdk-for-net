// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ContainerNetworkInterface type. </summary>
    public partial class ContainerNetworkInterface
    {
        /// <summary> Gets or sets the ContainerId compatibility property. </summary>
        public Azure.Core.ResourceIdentifier ContainerId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
