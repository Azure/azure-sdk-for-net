// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update;
    /// <summary>
    /// An immutable client-side representation of an Azure availability set.
    /// </summary>
    public interface IAvailabilitySet  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        IWrapper<Microsoft.Azure.Management.Compute.Fluent.Models.AvailabilitySetInner>,
        IUpdatable<Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update.IUpdate>
    {
        /// <returns>the update domain count of this availability set</returns>
        int UpdateDomainCount { get; }

        /// <returns>the fault domain count of this availability set</returns>
        int FaultDomainCount { get; }

        /// <returns>the resource IDs of the virtual machines in the availability set</returns>
        System.Collections.Generic.IList<string> VirtualMachineIds { get; }

        /// <returns>the statuses of the existing virtual machines in the availability set</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Fluent.Models.InstanceViewStatus> Statuses { get; }

    }
}