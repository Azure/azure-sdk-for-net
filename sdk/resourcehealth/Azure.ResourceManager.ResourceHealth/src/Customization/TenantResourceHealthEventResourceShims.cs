// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    public partial class TenantResourceHealthEventResource
    {
        /// <summary> Gets the collection of TenantResourceHealthEventImpactedResources. </summary>
        /// <returns> An object representing collection of TenantResourceHealthEventImpactedResources and their operations. </returns>
        // Same method-name compatibility pattern as ResourceHealthEventResourceShims: @@clientName renames the type, but not the parent-resource method generated from the TypeSpec resource name.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TenantResourceHealthEventImpactedResourceCollection GetTenantResourceHealthEventImpactedResources()
        {
            return GetTenantEventImpactedResources();
        }

        /// <summary> Gets the specific impacted resource in the tenant by an event. </summary>
        /// <param name="impactedResourceName"> Name of the Impacted Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Async counterpart for the same GA method-name shim from GetTenantEventImpactedResourceAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<TenantResourceHealthEventImpactedResource>> GetTenantResourceHealthEventImpactedResourceAsync(string impactedResourceName, CancellationToken cancellationToken = default)
        {
            return await GetTenantEventImpactedResourceAsync(impactedResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specific impacted resource in the tenant by an event. </summary>
        /// <param name="impactedResourceName"> Name of the Impacted Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Sync counterpart for the same GA method-name shim from GetTenantEventImpactedResource.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<TenantResourceHealthEventImpactedResource> GetTenantResourceHealthEventImpactedResource(string impactedResourceName, CancellationToken cancellationToken = default)
        {
            return GetTenantEventImpactedResource(impactedResourceName, cancellationToken);
        }

        /// <summary> Lists impacted resources in the tenant by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // This shim restores the long GA method name because the generated method name comes from the TypeSpec resource name and operation pattern.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventIdAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetByTenantIdAndEventIdAsync(filter, cancellationToken);
        }

        /// <summary> Lists impacted resources in the tenant by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Sync counterpart for the same GA method-name shim from GetByTenantIdAndEventId.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventId(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetByTenantIdAndEventId(filter, cancellationToken);
        }
    }
}
