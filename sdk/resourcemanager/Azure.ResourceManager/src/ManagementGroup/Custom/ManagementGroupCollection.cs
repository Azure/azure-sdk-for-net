// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ManagementGroups
{
    /// <summary>
    /// A class representing a collection of <see cref="ManagementGroupResource" /> and their operations.
    /// Each <see cref="ManagementGroupResource" /> in the collection will belong to the same instance of <see cref="TenantResource" />.
    /// To get a <see cref="ManagementGroupCollection" /> instance call the GetManagementGroups method from an instance of <see cref="TenantResource" />.
    /// </summary>
    public partial class ManagementGroupCollection : ArmCollection, IEnumerable<ManagementGroupResource>, IAsyncEnumerable<ManagementGroupResource>
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
        public virtual async Task<Response<ManagementGroupResource>> GetAsync(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            ManagementGroupGetOptions options = new ManagementGroupGetOptions
            {
                Expand = expand,
                Recurse = recurse,
                Filter = filter,
                CacheControl = cacheControl
            };
            return await GetAsync(groupId, options, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<ManagementGroupResource> Get(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            ManagementGroupGetOptions options = new ManagementGroupGetOptions
            {
                Expand = expand,
                Recurse = recurse,
                Filter = filter,
                CacheControl = cacheControl
            };
            return Get(groupId, options, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        public virtual async Task<Response<bool>> ExistsAsync(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            ManagementGroupGetOptions options = new ManagementGroupGetOptions
            {
                Expand = expand,
                Recurse = recurse,
                Filter = filter,
                CacheControl = cacheControl
            };
            return await ExistsAsync(groupId, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        public virtual Response<bool> Exists(string groupId, ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default)
        {
            ManagementGroupGetOptions options = new ManagementGroupGetOptions
            {
                Expand = expand,
                Recurse = recurse,
                Filter = filter,
                CacheControl = cacheControl
            };
            return Exists(groupId, options, cancellationToken);
        }
    }
}
