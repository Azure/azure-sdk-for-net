// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.AvailabilitySet.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure availability set.
    /// </summary>
    public interface IAvailabilitySet  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Compute.Fluent.IComputeManager,Models.AvailabilitySetInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<AvailabilitySet.Update.IUpdate>
    {
        /// <summary>
        /// Gets the fault domain count of this availability set.
        /// </summary>
        int FaultDomainCount { get; }

        /// <summary>
        /// Gets the resource IDs of the virtual machines in the availability set.
        /// </summary>
        System.Collections.Generic.ISet<string> VirtualMachineIds { get; }

        /// <return>The virtual machine sizes supported in the availability set.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> ListVirtualMachineSizes();

        /// <summary>
        /// Gets the statuses of the existing virtual machines in the availability set.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.InstanceViewStatus> Statuses { get; }

        /// <summary>
        /// Gets the availability set SKU.
        /// </summary>
        Models.AvailabilitySetSkuTypes Sku { get; }

        /// <summary>
        /// Gets the update domain count of this availability set.
        /// </summary>
        int UpdateDomainCount { get; }
    }
}