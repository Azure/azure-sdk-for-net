// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A class representing a collection of <see cref="VirtualMachineScaleSetVmResource" /> and their operations.
    /// Each <see cref="VirtualMachineScaleSetVmResource" /> in the collection will belong to the same instance of <see cref="VirtualMachineScaleSetResource" />.
    /// To get a <see cref="VirtualMachineScaleSetVmCollection" /> instance call the GetVirtualMachineScaleSetVms method from an instance of <see cref="VirtualMachineScaleSetResource" />.
    /// </summary>
    public partial class VirtualMachineScaleSetVmCollection : ArmCollection, IEnumerable<VirtualMachineScaleSetVmResource>, IAsyncEnumerable<VirtualMachineScaleSetVmResource>
    {
        /// <summary>
        /// Gets a list of all virtual machines in a VM scale sets.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines
        /// Operation Id: VirtualMachineScaleSetVMs_List
        /// </summary>
        /// <param name="filter"> The filter to apply to the operation. Allowed values are &apos;startswith(instanceView/statuses/code, &apos;PowerState&apos;) eq true&apos;, &apos;properties/latestModelApplied eq true&apos;, &apos;properties/latestModelApplied eq false&apos;. </param>
        /// <param name="select"> The list parameters. Allowed values are &apos;instanceView&apos;, &apos;instanceView/statuses&apos;. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetVmResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetVmResource> GetAllAsync(string filter = null, string select = null, string expand = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new VirtualMachineScaleSetVmCollectionGetAllOptions
            {
                Filter = filter,
                Select = select,
                Expand = expand
            }, cancellationToken);

        /// <summary>
        /// Gets a list of all virtual machines in a VM scale sets.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines
        /// Operation Id: VirtualMachineScaleSetVMs_List
        /// </summary>
        /// <param name="filter"> The filter to apply to the operation. Allowed values are &apos;startswith(instanceView/statuses/code, &apos;PowerState&apos;) eq true&apos;, &apos;properties/latestModelApplied eq true&apos;, &apos;properties/latestModelApplied eq false&apos;. </param>
        /// <param name="select"> The list parameters. Allowed values are &apos;instanceView&apos;, &apos;instanceView/statuses&apos;. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetVmResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSetVmResource> GetAll(string filter = null, string select = null, string expand = null, CancellationToken cancellationToken = default) =>
            GetAll(new VirtualMachineScaleSetVmCollectionGetAllOptions
            {
                Filter = filter,
                Select = select,
                Expand = expand
            }, cancellationToken);
    }
}
