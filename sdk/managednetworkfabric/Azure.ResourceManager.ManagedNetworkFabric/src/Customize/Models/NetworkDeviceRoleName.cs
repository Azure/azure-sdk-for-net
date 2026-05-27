// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct NetworkDeviceRoleName
    {
        // The TypeSpec generator does not emit this service-defined NPB value as a public constant.
        // Removing this shim would drop the shipped Npb member and break callers compiled against the GA SDK.

        /// <summary> NetworkDeviceRoleName-NPB(Network Packet Broker). </summary>
        public static NetworkDeviceRoleName Npb => new NetworkDeviceRoleName("NPB");
    }
}
