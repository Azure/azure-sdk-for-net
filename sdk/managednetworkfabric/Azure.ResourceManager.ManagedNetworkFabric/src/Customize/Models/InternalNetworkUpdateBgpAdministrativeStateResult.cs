// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // The generated property is IList<T> because the value now comes from a nested properties model.
    // Expose the shipped IReadOnlyList<T> signature for API compatibility.
    public partial class InternalNetworkUpdateBgpAdministrativeStateResult
    {
        /// <summary> NeighborAddress administrative status. </summary>
        public IReadOnlyList<NeighborAddressBgpAdministrativeStatus> NeighborAddressAdministrativeStatus
            => Properties?.NeighborAddressAdministrativeStatus as IReadOnlyList<NeighborAddressBgpAdministrativeStatus>;
    }
}
