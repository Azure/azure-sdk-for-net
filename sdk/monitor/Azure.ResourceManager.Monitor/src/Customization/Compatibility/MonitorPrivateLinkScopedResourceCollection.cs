// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.Monitor
{
    public partial class MonitorPrivateLinkScopedResourceCollection
    {
        /// <summary> Gets all scoped resources on a private link scope. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MonitorPrivateLinkScopedResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MonitorPrivateLinkScopedResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(kind: default, cancellationToken: cancellationToken);

        /// <summary> Gets all scoped resources on a private link scope. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MonitorPrivateLinkScopedResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MonitorPrivateLinkScopedResource> GetAll(CancellationToken cancellationToken)
            => GetAll(kind: default, cancellationToken: cancellationToken);
    }
}
