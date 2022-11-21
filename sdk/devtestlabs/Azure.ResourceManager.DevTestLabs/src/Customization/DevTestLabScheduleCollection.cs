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
    /// A class representing a collection of <see cref="DevTestLabScheduleResource" /> and their operations.
    /// Each <see cref="DevTestLabScheduleResource" /> in the collection will belong to the same instance of <see cref="DevTestLabResource" />.
    /// To get a <see cref="DevTestLabScheduleCollection" /> instance call the GetDevTestLabSchedules method from an instance of <see cref="DevTestLabResource" />.
    /// </summary>
    public partial class DevTestLabScheduleCollection : ArmCollection, IEnumerable<DevTestLabScheduleResource>, IAsyncEnumerable<DevTestLabScheduleResource>
    {
        /// <summary>
        /// List schedules in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules
        /// Operation Id: Schedules_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabScheduleResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabScheduleSchedulesClientDiagnostics.CreateScope("DevTestLabScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabScheduleSchedulesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabScheduleResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabScheduleSchedulesClientDiagnostics.CreateScope("DevTestLabScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabScheduleSchedulesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List schedules in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules
        /// Operation Id: Schedules_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabScheduleResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabScheduleResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabScheduleSchedulesClientDiagnostics.CreateScope("DevTestLabScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabScheduleSchedulesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabScheduleResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabScheduleSchedulesClientDiagnostics.CreateScope("DevTestLabScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabScheduleSchedulesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
