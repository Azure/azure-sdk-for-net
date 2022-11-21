// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabGlobalScheduleResource" /> and their operations.
    /// Each <see cref="DevTestLabGlobalScheduleResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="DevTestLabGlobalScheduleCollection" /> instance call the GetDevTestLabGlobalSchedules method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class DevTestLabGlobalScheduleCollection : ArmCollection, IEnumerable<DevTestLabGlobalScheduleResource>, IAsyncEnumerable<DevTestLabGlobalScheduleResource>
    {
        /// <summary>
        /// List schedules in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/schedules
        /// Operation Id: GlobalSchedules_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabGlobalScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabGlobalScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabGlobalScheduleResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabGlobalScheduleGlobalSchedulesClientDiagnostics.CreateScope("DevTestLabGlobalScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabGlobalScheduleGlobalSchedulesRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabGlobalScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabGlobalScheduleResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabGlobalScheduleGlobalSchedulesClientDiagnostics.CreateScope("DevTestLabGlobalScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabGlobalScheduleGlobalSchedulesRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabGlobalScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List schedules in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/schedules
        /// Operation Id: GlobalSchedules_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabGlobalScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabGlobalScheduleResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabGlobalScheduleResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabGlobalScheduleGlobalSchedulesClientDiagnostics.CreateScope("DevTestLabGlobalScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabGlobalScheduleGlobalSchedulesRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabGlobalScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabGlobalScheduleResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabGlobalScheduleGlobalSchedulesClientDiagnostics.CreateScope("DevTestLabGlobalScheduleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabGlobalScheduleGlobalSchedulesRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabGlobalScheduleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
