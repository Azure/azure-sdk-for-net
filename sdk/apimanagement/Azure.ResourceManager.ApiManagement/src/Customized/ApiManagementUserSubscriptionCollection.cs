// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiManagementUserSubscriptionResource" /> and their operations.
    /// Each <see cref="ApiManagementUserSubscriptionResource" /> in the collection will belong to the same instance of <see cref="ApiManagementUserResource" />.
    /// To get an <see cref="ApiManagementUserSubscriptionCollection" /> instance call the GetApiManagementUserSubscriptions method from an instance of <see cref="ApiManagementUserResource" />.
    /// </summary>
    public partial class ApiManagementUserSubscriptionCollection : ArmCollection, IEnumerable<ApiManagementUserSubscriptionResource>, IAsyncEnumerable<ApiManagementUserSubscriptionResource>
    {
        /// <summary>
        /// Lists the collection of subscriptions of the specified user.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users/{userId}/subscriptions
        /// Operation Id: UserSubscription_List
        /// </summary>
        /// <param name="filter"> | Field     |     Usage     |     Supported operators    | Supported functions               |&lt;/br&gt;|-------------|------------------------|-----------------------------------|&lt;/br&gt;|name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|stateComment | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|ownerId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|scope | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|productId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementUserSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementUserSubscriptionResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementUserSubscriptionResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementUserSubscriptionUserSubscriptionClientDiagnostics.CreateScope("ApiManagementUserSubscriptionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementUserSubscriptionUserSubscriptionRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementUserSubscriptionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementUserSubscriptionResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementUserSubscriptionUserSubscriptionClientDiagnostics.CreateScope("ApiManagementUserSubscriptionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementUserSubscriptionUserSubscriptionRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementUserSubscriptionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the collection of subscriptions of the specified user.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users/{userId}/subscriptions
        /// Operation Id: UserSubscription_List
        /// </summary>
        /// <param name="filter"> | Field     |     Usage     |     Supported operators    | Supported functions               |&lt;/br&gt;|-------------|------------------------|-----------------------------------|&lt;/br&gt;|name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|stateComment | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|ownerId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|scope | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;|productId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementUserSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementUserSubscriptionResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementUserSubscriptionResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementUserSubscriptionUserSubscriptionClientDiagnostics.CreateScope("ApiManagementUserSubscriptionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementUserSubscriptionUserSubscriptionRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementUserSubscriptionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementUserSubscriptionResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementUserSubscriptionUserSubscriptionClientDiagnostics.CreateScope("ApiManagementUserSubscriptionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementUserSubscriptionUserSubscriptionRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementUserSubscriptionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
