// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility shims: map old GA 1.0.0 method names to new generated names.
// The TypeSpec generator derives method names from the resource class name (e.g. "ImpactedResource"
// → GetImpactedResources()). After [CodeGenType] renames the class to ResourceHealthEventImpactedResource,
// the getter on the parent resource STILL uses the original generated name. These shims preserve the
// GA method names. @@clientName cannot rename methods on parent Resource classes.

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
        // GA 1.0.0 backward compatibility shim: preserves the old method name "GetResourceHealthEventImpactedResources".
        // The new generated method is "GetImpactedResources()" (derived from TypeSpec resource name "ImpactedResource").
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ResourceHealthEventImpactedResourceCollection GetResourceHealthEventImpactedResources()
        {
            return GetImpactedResources();
        }

        /// <summary> Gets the specific impacted resource in the subscription by an event. </summary>
        /// <param name="impactedResourceName"> Name of the Impacted Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old method name "GetResourceHealthEventImpactedResourceAsync".
        // The new generated method is "GetImpactedResourceAsync()".
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ResourceHealthEventImpactedResource>> GetResourceHealthEventImpactedResourceAsync(string impactedResourceName, CancellationToken cancellationToken = default)
        {
            return await GetImpactedResourceAsync(impactedResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specific impacted resource in the subscription by an event. </summary>
        /// <param name="impactedResourceName"> Name of the Impacted Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old method name "GetResourceHealthEventImpactedResource".
        // The new generated method is "GetImpactedResource()".
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ResourceHealthEventImpactedResource> GetResourceHealthEventImpactedResource(string impactedResourceName, CancellationToken cancellationToken = default)
        {
            return GetImpactedResource(impactedResourceName, cancellationToken);
        }

        /// <summary> Lists impacted resources in the subscription by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old method name
        // "GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventIdAsync".
        // The new generated method is "GetBySubscriptionIdAndEventIdAsync()".
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventIdAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetBySubscriptionIdAndEventIdAsync(filter, cancellationToken);
        }

        /// <summary> Lists impacted resources in the subscription by an event (Security Advisory). </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old method name
        // "GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventId".
        // The new generated method is "GetBySubscriptionIdAndEventId()".
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventId(string filter = default, CancellationToken cancellationToken = default)
        {
            return GetBySubscriptionIdAndEventId(filter, cancellationToken);
        }
    }
}