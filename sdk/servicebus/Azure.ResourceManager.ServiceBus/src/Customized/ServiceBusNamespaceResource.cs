// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceBus
{
    public partial class ServiceBusNamespaceResource
    {
        /// <summary>
        /// Updates a service namespace. Once created, this namespace's resource manifest is immutable. This operation is idempotent.
        /// </summary>
        /// <param name="patch"> Parameters supplied to update a namespace resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ServiceBusNamespaceResource>> UpdateAsync(Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespacePatch patch, CancellationToken cancellationToken = default)
        {
            var lro = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(lro.Value, lro.GetRawResponse());
        }

        /// <summary>
        /// Updates a service namespace. Once created, this namespace's resource manifest is immutable. This operation is idempotent.
        /// </summary>
        /// <param name="patch"> Parameters supplied to update a namespace resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceBusNamespaceResource> Update(Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespacePatch patch, CancellationToken cancellationToken = default)
        {
            var lro = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(lro.Value, lro.GetRawResponse());
        }
    }
}
