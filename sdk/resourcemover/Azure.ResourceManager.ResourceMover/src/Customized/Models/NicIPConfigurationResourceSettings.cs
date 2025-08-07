// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines NIC IP configuration properties. </summary>
    public partial class NicIPConfigurationResourceSettings
    {
        /// <summary> Gets or sets the private IP address of the network interface IP Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress PrivateIPAddress
        {
            get => IPAddress.TryParse(PrivateIPAddressStringValue, out IPAddress ipAddress) ? ipAddress : null;
            set => PrivateIPAddressStringValue = value.ToString();
        }
    }
}
