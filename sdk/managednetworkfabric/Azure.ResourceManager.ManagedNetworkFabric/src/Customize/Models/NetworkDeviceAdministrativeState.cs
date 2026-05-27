// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct NetworkDeviceAdministrativeState
    {
        // The TypeSpec generator does not emit this service-defined value as a public constant.
        // Removing this shim would drop the shipped Rma member and break callers compiled against the GA SDK.

        /// <summary> Device AdministrativeState-RMA. </summary>
        public static NetworkDeviceAdministrativeState Rma => new NetworkDeviceAdministrativeState("RMA");
    }
}
