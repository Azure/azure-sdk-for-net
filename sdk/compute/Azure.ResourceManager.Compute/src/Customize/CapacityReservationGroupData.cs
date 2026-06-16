// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class CapacityReservationGroupData
    {
        /// <summary> A list of all capacity reservation instance views. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<CapacityReservationInstanceViewWithName> InstanceViewCapacityReservations
        {
            get => InstanceView?.CapacityReservations;
        }

        // Backward compatibility: the generated Compute-local property is named CapacityReservationResources and uses
        // ComputeSubResourceData. Restore the old CapacityReservations property with ARM common SubResource.
        /// <summary> A list of all capacity reservation resource ids that belong to capacity reservation group. </summary>
        public IReadOnlyList<SubResource> CapacityReservations => CapacityReservationResources.ToSubResources();

        // Backward compatibility: the generated Compute-local property is named AssociatedVirtualMachineResources and
        // uses ComputeSubResourceData. Restore the old VirtualMachinesAssociated property with ARM common SubResource.
        /// <summary> A list of references to all virtual machines associated to the capacity reservation group. </summary>
        public IReadOnlyList<SubResource> VirtualMachinesAssociated => AssociatedVirtualMachineResources.ToSubResources();

        // Backward compatibility: the generated Compute-local property is named SharingSubscriptionResources and uses
        // ComputeWriteableSubResourceData. Restore the old SharingSubscriptionIds property with ARM common WritableSubResource.
        /// <summary> Specifies an array of subscription resource IDs that capacity reservation group is shared with. </summary>
        [Obsolete("Use SharingSubscriptionResources instead. This compatibility property cannot be used for mutation.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> SharingSubscriptionIds => throw new NotSupportedException("Use SharingSubscriptionResources instead.");
    }
}
