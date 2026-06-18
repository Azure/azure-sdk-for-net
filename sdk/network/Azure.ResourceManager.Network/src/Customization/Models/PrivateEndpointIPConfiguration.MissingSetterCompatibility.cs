// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the PrivateEndpointIPConfiguration type. </summary>
    public partial class PrivateEndpointIPConfiguration
    {
        /// <summary> Gets or sets the PrivateIPAddress compatibility property. </summary>
        public System.Net.IPAddress PrivateIPAddress
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
