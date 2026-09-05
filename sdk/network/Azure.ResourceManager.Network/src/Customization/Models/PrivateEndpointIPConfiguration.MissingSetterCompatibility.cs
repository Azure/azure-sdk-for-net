// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Network;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the PrivateEndpointIPConfiguration type. </summary>
    public partial class PrivateEndpointIPConfiguration
    {
        // The TypeSpec migration moved the wire value into the internal Properties model. Keep the
        // previously shipped IPAddress property connected to that model for serialization and deserialization.
        /// <summary> Gets or sets the PrivateIPAddress compatibility property. </summary>
        [WirePath("properties.privateIPAddress")]
        public System.Net.IPAddress PrivateIPAddress
        {
            get => System.Net.IPAddress.TryParse(Properties?.PrivateIPAddress, out System.Net.IPAddress ipAddress) ? ipAddress : null;
            set
            {
                if (value is null)
                {
                    if (Properties != null)
                    {
                        Properties.PrivateIPAddress = null;
                    }
                    return;
                }

                Properties ??= new PrivateEndpointIPConfigurationProperties();
                Properties.PrivateIPAddress = value.ToString();
            }
        }
    }
}
