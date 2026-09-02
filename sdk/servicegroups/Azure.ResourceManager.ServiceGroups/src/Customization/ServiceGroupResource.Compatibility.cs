// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.ServiceGroups
{
    public partial class ServiceGroupResource
    {
        /// <summary>
        /// Gets the ancestors of this service group.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A collection of the service group's ancestors.</returns>
        public virtual AsyncPageable<ServiceGroupResource> GetAncestorsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new ServiceGroupAncestorsAsyncPageable(
                Client,
                _serviceGroupsOperationGroupRestClient,
                Id.Name,
                context);
        }

        /// <summary>
        /// Gets the ancestors of this service group.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A collection of the service group's ancestors.</returns>
        public virtual Pageable<ServiceGroupResource> GetAncestors(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new ServiceGroupAncestorsPageable(
                Client,
                _serviceGroupsOperationGroupRestClient,
                Id.Name,
                context);
        }
    }
}
