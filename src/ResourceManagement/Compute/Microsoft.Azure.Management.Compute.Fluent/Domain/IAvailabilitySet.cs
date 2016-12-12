// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;
    using AvailabilitySet.Update;

    /// <summary>
    /// An immutable client-side representation of an Azure availability set.
    /// </summary>
    public interface IAvailabilitySet :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        IWrapper<Models.AvailabilitySetInner>,
        IUpdatable<AvailabilitySet.Update.IUpdate>
    {
        /// <return>The fault domain count of this availability set.</return>
        int FaultDomainCount { get; }

        /// <return>The resource IDs of the virtual machines in the availability set.</return>
        System.Collections.Generic.IList<string> VirtualMachineIds { get; }

        /// <return>The statuses of the existing virtual machines in the availability set.</return>
        System.Collections.Generic.IList<Models.InstanceViewStatus> Statuses { get; }

        /// <return>The update domain count of this availability set.</return>
        int UpdateDomainCount { get; }
    }
}