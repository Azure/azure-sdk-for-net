// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;

namespace Azure.ResourceManager.ResourceHealth
{
    public partial class TenantResourceHealthEventResource
    {
        /// <summary> Lists impacted resources in the tenant by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthEventImpactedResourceData"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventIdAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetByTenantIdAndEventIdAsync(filter, cancellationToken);
        }

        /// <summary> Lists impacted resources in the tenant by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthEventImpactedResourceData"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventId(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetByTenantIdAndEventId(filter, cancellationToken);
        }
    }
}
