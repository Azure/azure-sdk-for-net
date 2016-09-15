/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Update;
    using Microsoft.Azure.Management.Compute.Models;
    /// <summary>
    /// An immutable client-side representation of an Azure availability set.
    /// </summary>
    public interface IAvailabilitySet  :
        IGroupableResource,
        IRefreshable<IAvailabilitySet>,
        IWrapper<AvailabilitySetInner>,
        IUpdatable<IUpdate>
    {
        /// <summary>
        /// Returns the update domain count of an availability set.
        /// <p>
        /// An update domain represents the group of virtual
        /// machines and underlying physical hardware that can be rebooted at the same time.
        /// </summary>
        /// <returns>the update domain count</returns>
        int? UpdateDomainCount { get; }

        /// <summary>
        /// Returns the fault domain count of availability set.
        /// <p>
        /// A fault domain represents the group of virtual
        /// machines that shares common power source and network switch.
        /// </summary>
        /// <returns>the fault domain count</returns>
        int? FaultDomainCount { get; }

        /// <summary>
        /// Lists the resource IDs of the virtual machines in the availability set.
        /// </summary>
        /// <returns>list of resource ID strings</returns>
        IList<string> VirtualMachineIds { get; }

        /// <summary>
        /// Lists the statuses of the existing virtual machines in the availability set.
        /// </summary>
        /// <returns>list of virtual machine statuses</returns>
        IList<InstanceViewStatus> Statuses { get; }

    }
}