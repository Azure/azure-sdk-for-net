// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ManagementGroups.Models;

[assembly:CodeGenSuppressType("SearchOptions")]
[assembly:CodeGenSuppressType("EntityViewOptions")]
[assembly:CodeGenSuppressType("TenantExtensions")] // Moved code to Custom/Tenant
[assembly:CodeGenSuppressType("AzureAsyncOperationResults")]
[assembly:CodeGenSuppressType("ErrorResponse")]
[assembly:CodeGenSuppressType("ErrorDetails")] // No target and additionalInfo properties, therefore it's not replaced by common type
[assembly:CodeGenSuppressType("ManagementGroupUpdateOperation")]
namespace Azure.ResourceManager.ManagementGroups
{
    /// <summary> A Class representing a ManagementGroup along with the instance operations that can be performed on it. </summary>
    public partial class ManagementGroupResource : ArmResource
    {
        /// <summary>
        /// Get the details of the management group.
        ///
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}
        /// Operation Id: ManagementGroups_Get
        /// </summary>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ManagementGroupResource>> GetAsync(ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default) =>
            await GetAsync(new ManagementGroupResourceGetOptions
            {
                Expand = expand,
                Recurse = recurse,
                Filter = filter,
                CacheControl = cacheControl
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the details of the management group.
        ///
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}
        /// Operation Id: ManagementGroups_Get
        /// </summary>
        /// <param name="expand"> The $expand=children query string parameter allows clients to request inclusion of children in the response payload.  $expand=path includes the path from the root group to the current group.  $expand=ancestors includes the ancestor Ids of the current group. </param>
        /// <param name="recurse"> The $recurse=true query string parameter allows clients to request inclusion of entire hierarchy in the response payload. Note that  $expand=children must be passed up if $recurse is set to true. </param>
        /// <param name="filter"> A filter which allows the exclusion of subscriptions from results (i.e. &apos;$filter=children.childType ne Subscription&apos;). </param>
        /// <param name="cacheControl"> Indicates whether the request should utilize any caches. Populate the header with &apos;no-cache&apos; value to bypass existing caches. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagementGroupResource> Get(ManagementGroupExpandType? expand = null, bool? recurse = null, string filter = null, string cacheControl = null, CancellationToken cancellationToken = default) =>
            Get(new ManagementGroupResourceGetOptions
            {
                Expand = expand,
                Recurse = recurse,
                Filter = filter,
                CacheControl = cacheControl
            }, cancellationToken);
    }
}
