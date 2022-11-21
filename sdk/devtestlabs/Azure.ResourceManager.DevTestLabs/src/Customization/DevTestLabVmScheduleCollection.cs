// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabVmScheduleResource" /> and their operations.
    /// Each <see cref="DevTestLabVmScheduleResource" /> in the collection will belong to the same instance of <see cref="DevTestLabVmResource" />.
    /// To get a <see cref="DevTestLabVmScheduleCollection" /> instance call the GetDevTestLabVmSchedules method from an instance of <see cref="DevTestLabVmResource" />.
    /// </summary>
    public partial class DevTestLabVmScheduleCollection : ArmCollection, IEnumerable<DevTestLabVmScheduleResource>, IAsyncEnumerable<DevTestLabVmScheduleResource>
    {
        /// <summary>
        /// List schedules in a given virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/virtualmachines/{virtualMachineName}/schedules
        /// Operation Id: VirtualMachineSchedules_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabVmScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabVmScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabVmScheduleResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabVmScheduleVmSchedulesClientDiagnostics.CreateScope("DevTestLabVmScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabVmScheduleVmSchedulesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabVmScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabVmScheduleResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabVmScheduleVmSchedulesClientDiagnostics.CreateScope("DevTestLabVmScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabVmScheduleVmSchedulesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabVmScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List schedules in a given virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/virtualmachines/{virtualMachineName}/schedules
        /// Operation Id: VirtualMachineSchedules_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabVmScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabVmScheduleResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabVmScheduleResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabVmScheduleVmSchedulesClientDiagnostics.CreateScope("DevTestLabVmScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabVmScheduleVmSchedulesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabVmScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabVmScheduleResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabVmScheduleVmSchedulesClientDiagnostics.CreateScope("DevTestLabVmScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabVmScheduleVmSchedulesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabVmScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
