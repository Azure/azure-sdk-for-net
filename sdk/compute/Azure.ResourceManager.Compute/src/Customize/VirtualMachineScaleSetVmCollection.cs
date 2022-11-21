// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

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
        public virtual AsyncPageable<VirtualMachineScaleSetVmResource> GetAllAsync(string filter = null, string select = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineScaleSetVmResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineScaleSetVmVirtualMachineScaleSetVmsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVmResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualMachineScaleSetVmResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineScaleSetVmVirtualMachineScaleSetVmsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVmResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

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
        public virtual Pageable<VirtualMachineScaleSetVmResource> GetAll(string filter = null, string select = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineScaleSetVmResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVmResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualMachineScaleSetVmResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVmResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
