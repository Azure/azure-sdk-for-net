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
    /// A class representing a collection of <see cref="DevTestLabNotificationChannelResource" /> and their operations.
    /// Each <see cref="DevTestLabNotificationChannelResource" /> in the collection will belong to the same instance of <see cref="DevTestLabResource" />.
    /// To get a <see cref="DevTestLabNotificationChannelCollection" /> instance call the GetDevTestLabNotificationChannels method from an instance of <see cref="DevTestLabResource" />.
    /// </summary>
    public partial class DevTestLabNotificationChannelCollection : ArmCollection, IEnumerable<DevTestLabNotificationChannelResource>, IAsyncEnumerable<DevTestLabNotificationChannelResource>
    {
        /// <summary>
        /// List notification channels in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/notificationchannels
        /// Operation Id: NotificationChannels_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=webHookUrl)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabNotificationChannelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabNotificationChannelResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabNotificationChannelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabNotificationChannelNotificationChannelsClientDiagnostics.CreateScope("DevTestLabNotificationChannelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabNotificationChannelNotificationChannelsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabNotificationChannelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabNotificationChannelResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabNotificationChannelNotificationChannelsClientDiagnostics.CreateScope("DevTestLabNotificationChannelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabNotificationChannelNotificationChannelsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabNotificationChannelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List notification channels in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/notificationchannels
        /// Operation Id: NotificationChannels_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=webHookUrl)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabNotificationChannelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabNotificationChannelResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabNotificationChannelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabNotificationChannelNotificationChannelsClientDiagnostics.CreateScope("DevTestLabNotificationChannelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabNotificationChannelNotificationChannelsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabNotificationChannelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabNotificationChannelResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabNotificationChannelNotificationChannelsClientDiagnostics.CreateScope("DevTestLabNotificationChannelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabNotificationChannelNotificationChannelsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabNotificationChannelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
