// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct NetworkFabricAdministrativeState
    {
        // The TypeSpec generator does not emit these service-defined administrative states as public constants.
        // Removing these shims would drop the shipped Mat/Rma members and break callers compiled against the GA SDK.

        /// <summary> MAT(Manual Action Taken) Administrative State. </summary>
        public static NetworkFabricAdministrativeState Mat => new NetworkFabricAdministrativeState("MAT");

        /// <summary> RMA(Return Material Authorization) Administrative State. </summary>
        public static NetworkFabricAdministrativeState Rma => new NetworkFabricAdministrativeState("RMA");
    }
}
