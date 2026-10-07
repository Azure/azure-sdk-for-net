// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the NetworkIPConfigurationBgpPeeringAddress type. </summary>
    public partial class NetworkIPConfigurationBgpPeeringAddress
    {
        // TypeSpec customization restores the shipped acronym casing, but these service-populated
        // properties are still emitted only through serialization/constructor code. Add the public
        // surface with backing storage so generated serialization uses the same functional members.
        /// <summary> The list of custom BGP peering addresses which belong to IP configuration. </summary>
        public IList<string> CustomBgpIPAddresses { get; private set; }
        /// <summary> The list of default BGP peering addresses which belong to IP configuration. </summary>
        public IReadOnlyList<string> DefaultBgpIPAddresses { get; private set; }
        /// <summary> The ID of IP configuration which belongs to gateway. </summary>
        public string IPConfigurationId { get; set; }
        /// <summary> The list of tunnel public IP addresses which belong to IP configuration. </summary>
        public IReadOnlyList<string> TunnelIPAddresses { get; private set; }
    }
}
