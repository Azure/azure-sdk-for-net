// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A Class representing an ApiManagementGroup along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="ApiManagementGroupResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetApiManagementGroupResource method.
    /// Otherwise you can get one from its parent resource <see cref="ApiManagementServiceResource" /> using the GetApiManagementGroup method.
    /// </summary>
    public partial class ApiManagementGroupResource : ArmResource
    {
        /// <summary>
        /// Lists a collection of user entities associated with the group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}/users
        /// Operation Id: GroupUser_List
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| firstName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| lastName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| email | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| registrationDate | filter | ge, le, eq, ne, gt, lt |     |&lt;/br&gt;| note | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementGroupUserData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementGroupUserData> GetGroupUsersAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementGroupUserData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _groupUserClientDiagnostics.CreateScope("ApiManagementGroupResource.GetGroupUsers");
                scope.Start();
                try
                {
                    var response = await _groupUserRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementGroupUserData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _groupUserClientDiagnostics.CreateScope("ApiManagementGroupResource.GetGroupUsers");
                scope.Start();
                try
                {
                    var response = await _groupUserRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Lists a collection of user entities associated with the group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}/users
        /// Operation Id: GroupUser_List
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| firstName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| lastName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| email | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| registrationDate | filter | ge, le, eq, ne, gt, lt |     |&lt;/br&gt;| note | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementGroupUserData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementGroupUserData> GetGroupUsers(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementGroupUserData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _groupUserClientDiagnostics.CreateScope("ApiManagementGroupResource.GetGroupUsers");
                scope.Start();
                try
                {
                    var response = _groupUserRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementGroupUserData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _groupUserClientDiagnostics.CreateScope("ApiManagementGroupResource.GetGroupUsers");
                scope.Start();
                try
                {
                    var response = _groupUserRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
