// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.Compute
{
    public partial class CapacityReservationCollection
    {
        /// <summary> Lists all of the capacity reservations in the specified capacity reservation group. Use the nextLink property in the response to get the next page of capacity reservations. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}/capacityReservations. </description> </item> <item> <term> Operation Id. </term> <description> CapacityReservations_ListByCapacityReservationGroup. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CapacityReservationResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, cancellationToken);

        /// <summary> Lists all of the capacity reservations in the specified capacity reservation group. Use the nextLink property in the response to get the next page of capacity reservations. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}/capacityReservations. </description> </item> <item> <term> Operation Id. </term> <description> CapacityReservations_ListByCapacityReservationGroup. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CapacityReservationResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, cancellationToken);
    }
}
