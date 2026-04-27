// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat shims: the previous SDK exposed listAncestors on ServiceGroupCollection
// (taking a service group name), but the TypeSpec spec models it as an action on the
// ServiceGroup resource. Forward calls to ServiceGroupResource to keep the public API.

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.ServiceGroups
{
    public partial class ServiceGroupCollection
    {
        /// <summary> Get the details of the serviceGroup's ancestors. </summary>
        /// <param name="serviceGroupName"> The name of the service group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ServiceGroupResource> GetAncestors(string serviceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serviceGroupName, nameof(serviceGroupName));

            ResourceIdentifier resourceId = ServiceGroupResource.CreateResourceIdentifier(serviceGroupName);
            return Client.GetServiceGroupResource(resourceId).GetAncestors(cancellationToken);
        }

        /// <summary> Get the details of the serviceGroup's ancestors. </summary>
        /// <param name="serviceGroupName"> The name of the service group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ServiceGroupResource> GetAncestorsAsync(string serviceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serviceGroupName, nameof(serviceGroupName));

            ResourceIdentifier resourceId = ServiceGroupResource.CreateResourceIdentifier(serviceGroupName);
            return Client.GetServiceGroupResource(resourceId).GetAncestorsAsync(cancellationToken);
        }
    }
}
