// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility shims: map old GA 1.0.0 method names to new generated names on
// TenantResourceHealthEventResource. Same rationale as ResourceHealthEventResourceShims.cs —
// the generator derives method names from TypeSpec resource names, and [CodeGenType] renames
// the class but not the methods on parent resources.

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
        // GA 1.0.0 backward compatibility shim: preserves the old method name "GetTenantResourceHealthEventImpactedResources".
        // The new generated method is "GetTenantEventImpactedResources()" (derived from TypeSpec resource name "TenantEventImpactedResource").
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TenantResourceHealthEventImpactedResourceCollection GetTenantResourceHealthEventImpactedResources()
        {
            return GetTenantEventImpactedResources();
        }

        /// <summary> Gets the specific impacted resource in the tenant by an event. </summary>
        /// <param name="impactedResourceName"> Name of the Impacted Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old method name "GetTenantResourceHealthEventImpactedResourceAsync".
        // The new generated method is "GetTenantEventImpactedResourceAsync()".
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<TenantResourceHealthEventImpactedResource>> GetTenantResourceHealthEventImpactedResourceAsync(string impactedResourceName, CancellationToken cancellationToken = default)
        {
            return await GetTenantEventImpactedResourceAsync(impactedResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specific impacted resource in the tenant by an event. </summary>
        /// <param name="impactedResourceName"> Name of the Impacted Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old method name "GetTenantResourceHealthEventImpactedResource".
        // The new generated method is "GetTenantEventImpactedResource()".
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<TenantResourceHealthEventImpactedResource> GetTenantResourceHealthEventImpactedResource(string impactedResourceName, CancellationToken cancellationToken = default)
        {
            return GetTenantEventImpactedResource(impactedResourceName, cancellationToken);
        }

        /// <summary> Lists impacted resources in the tenant by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old method name
        // "GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventIdAsync".
        // The new generated method is "GetByTenantIdAndEventIdAsync()".
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventIdAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetByTenantIdAndEventIdAsync(filter, cancellationToken);
        }

        /// <summary> Lists impacted resources in the tenant by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old method name
        // "GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventId".
        // The new generated method is "GetByTenantIdAndEventId()".
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventId(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetByTenantIdAndEventId(filter, cancellationToken);
        }
    }
}
