// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public readonly partial struct BfdAdministrativeState
    {
        /// <summary> Represents the MAT(Manual Action Taken) state of BFD administrative state. </summary>
        public static BfdAdministrativeState Mat => MAT;

        /// <summary> Represents the RMA(Return Material Authorization) state of BFD administrative state. </summary>
        public static BfdAdministrativeState Rma => RMA;
    }
}
