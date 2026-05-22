// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Network and credentials configuration currently applied to terminal server. </summary>
    public partial class TerminalServerConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="TerminalServerConfiguration"/>. </summary>
        /// <param name="username"> Username for the terminal server connection. </param>
        /// <param name="password"> Password for the terminal server connection. </param>
        /// <param name="primaryIpv4Prefix"> IPv4 Address Prefix. </param>
        /// <param name="secondaryIpv4Prefix"> Secondary IPv4 Address Prefix. </param>
        public TerminalServerConfiguration(string username, string password, string primaryIpv4Prefix, string secondaryIpv4Prefix)
            : base(username, password, serialNumber: null, primaryIpv4Prefix, primaryIpv6Prefix: null, secondaryIpv4Prefix, secondaryIpv6Prefix: null, additionalBinaryDataProperties: null)
        {
        }
    }
}
