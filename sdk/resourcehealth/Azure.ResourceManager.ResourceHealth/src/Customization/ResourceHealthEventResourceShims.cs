// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    public partial class ResourceHealthEventResource
    {
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
