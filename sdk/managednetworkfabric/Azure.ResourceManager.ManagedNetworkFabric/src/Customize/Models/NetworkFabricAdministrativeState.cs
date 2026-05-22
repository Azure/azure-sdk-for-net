// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct NetworkFabricAdministrativeState
    {
        /// <summary> MAT(Manual Action Taken) Administrative State. </summary>
        public static NetworkFabricAdministrativeState Mat => MAT;

        /// <summary> RMA(Return Material Authorization) Administrative State. </summary>
        public static NetworkFabricAdministrativeState Rma => RMA;
    }
}
