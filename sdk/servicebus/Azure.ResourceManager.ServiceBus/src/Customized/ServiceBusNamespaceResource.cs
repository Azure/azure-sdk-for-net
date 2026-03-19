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
    /// <summary>
    /// Customizations for ServiceBusNamespaceResource:
    ///
    /// 1. Update overloads: The previous AutoRest-generated SDK exposed Update as a non-LRO operation.
    ///    These overloads preserve that API surface for existing consumers.
    ///
    /// 2. Suppress misplaced GetAuthorizationRules/GetAuthorizationRulesAsync: Due to a TypeSpec ARM
    ///    library bug, @segmentOf produces a camelCase segment that doesn't match the explicit @segment
    ///    on the resource path param, causing the List operation for namespace authorization rules to be
    ///    incorrectly placed here instead of on ServiceBusNamespaceAuthorizationRuleCollection.
    ///    See: https://github.com/Azure/azure-sdk-for-net/issues/57216
    /// </summary>
    [CodeGenSuppress("GetAuthorizationRulesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAuthorizationRules", typeof(CancellationToken))]
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
