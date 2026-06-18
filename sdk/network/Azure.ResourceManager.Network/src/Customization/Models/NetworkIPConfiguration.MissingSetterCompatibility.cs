// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the NetworkIPConfiguration type. </summary>
    public partial class NetworkIPConfiguration
    {
        /// <summary> Gets or sets the PrivateIPAddress compatibility property. </summary>
        public System.String PrivateIPAddress
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the PrivateIPAllocationMethod compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkIPAllocationMethod> PrivateIPAllocationMethod
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the PublicIPAddress compatibility property. </summary>
        public Azure.ResourceManager.Network.PublicIPAddressData PublicIPAddress
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the Subnet compatibility property. </summary>
        public Azure.ResourceManager.Network.SubnetData Subnet
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
