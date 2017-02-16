// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using AvailabilitySet.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure availability set.
    /// </summary>
    public interface IAvailabilitySet  :
        IGroupableResource<IComputeManager>,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        IHasInner<Models.AvailabilitySetInner>,
        IUpdatable<AvailabilitySet.Update.IUpdate>
    {
        /// <summary>
        /// Gets the fault domain count of this availability set.
        /// </summary>
        int FaultDomainCount { get; }

        /// <summary>
        /// Gets the resource IDs of the virtual machines in the availability set.
        /// </summary>
        System.Collections.Generic.IList<string> VirtualMachineIds { get; }

        /// <summary>
        /// Gets the statuses of the existing virtual machines in the availability set.
        /// </summary>
        System.Collections.Generic.IList<Models.InstanceViewStatus> Statuses { get; }

        /// <summary>
        /// Gets the availability set sku.
        /// </summary>
        Models.AvailabilitySetSkuTypes Sku { get; }

        /// <summary>
        /// Gets the update domain count of this availability set.
        /// </summary>
        int UpdateDomainCount { get; }
    }
}