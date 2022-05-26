// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.ManagementGroups.Models;

namespace Azure.ResourceManager.Resources
{
    public partial class TenantResource
    {
        /// <summary>
        /// Get the details of the management group.
        ///
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}
        /// Operation Id: ManagementGroups_Get
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ManagementGroupResource>> GetManagementGroupAsync(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            ManagementGroupGetOptions options = new ManagementGroupGetOptions
            {
                Expand = expand,
                Recurse = recurse,
                Filter = filter,
                CacheControl = cacheControl
            };
            return await GetManagementGroups().GetAsync(groupId, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the details of the management group.
        ///
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}
        /// Operation Id: ManagementGroups_Get
        /// </summary>
        /// <param name="groupId"> Management Group ID. </param>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<ManagementGroupResource> GetManagementGroup(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            ManagementGroupGetOptions options = new ManagementGroupGetOptions
            {
                Expand = expand,
                Recurse = recurse,
                Filter = filter,
                CacheControl = cacheControl
            };
            return GetManagementGroups().Get(groupId, options, cancellationToken);
        }
    }
}
