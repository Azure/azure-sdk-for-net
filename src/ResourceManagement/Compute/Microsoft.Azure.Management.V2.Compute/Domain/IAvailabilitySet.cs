// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure availability set.
    /// </summary>
    public interface IAvailabilitySet :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet>,
        IWrapper<Microsoft.Azure.Management.Compute.Models.AvailabilitySetInner>,
        IUpdatable<Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Update.IUpdate>
    {
        /// <returns>the update domain count of this availability set</returns>
        int? UpdateDomainCount { get; }

        /// <returns>the fault domain count of this availability set</returns>
        int? FaultDomainCount { get; }

        /// <returns>the resource IDs of the virtual machines in the availability set</returns>
        List<string> VirtualMachineIds { get; }

        /// <returns>the statuses of the existing virtual machines in the availability set</returns>
        List<Microsoft.Azure.Management.Compute.Models.InstanceViewStatus> Statuses { get; }

    }
}