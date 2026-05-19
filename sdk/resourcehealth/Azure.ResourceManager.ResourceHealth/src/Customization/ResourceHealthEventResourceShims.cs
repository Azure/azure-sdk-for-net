// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    public partial class ResourceHealthEventResource
    {
        /// <summary> Gets the collection of ResourceHealthEventImpactedResources. </summary>
        /// <returns> An object representing collection of ResourceHealthEventImpactedResources and their operations. </returns>
        // This shim restores the GA method name because the generator derives parent-resource method names from the TypeSpec resource name,
        // and @@clientName cannot rename methods on the parent resource class.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ResourceHealthEventImpactedResourceCollection GetResourceHealthEventImpactedResources()
        {
            return GetImpactedResources();
        }

        /// <summary> Gets the specific impacted resource in the subscription by an event. </summary>
        /// <param name="impactedResourceName"> Name of the Impacted Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Async counterpart for the same GA method-name shim from GetImpactedResourceAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ResourceHealthEventImpactedResource>> GetResourceHealthEventImpactedResourceAsync(string impactedResourceName, CancellationToken cancellationToken = default)
        {
            return await GetImpactedResourceAsync(impactedResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specific impacted resource in the subscription by an event. </summary>
        /// <param name="impactedResourceName"> Name of the Impacted Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Sync counterpart for the same GA method-name shim from GetImpactedResource.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ResourceHealthEventImpactedResource> GetResourceHealthEventImpactedResource(string impactedResourceName, CancellationToken cancellationToken = default)
        {
            return GetImpactedResource(impactedResourceName, cancellationToken);
        }

        /// <summary> Lists impacted resources in the subscription by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // This shim restores the long GA method name because the generated method name comes from the TypeSpec resource name and operation pattern.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventIdAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetBySubscriptionIdAndEventIdAsync(filter, cancellationToken);
        }

        /// <summary> Lists impacted resources in the subscription by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Sync counterpart for the same GA method-name shim from GetBySubscriptionIdAndEventId.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventId(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetBySubscriptionIdAndEventId(filter, cancellationToken);
        }
    }
}
