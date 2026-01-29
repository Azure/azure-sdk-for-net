// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ServiceBus
{
    /// <summary>
    /// A Class representing an ServiceBusNamespace along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="ServiceBusNamespaceResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetServiceBusNamespaceResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetServiceBusNamespace method.
    /// </summary>
    public partial class ServiceBusNamespaceResource : ArmResource
    {
        /// <summary>
        /// Creates or updates a namespace. Once created, this namespace's resource manifest is immutable. This operation is idempotent.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceBusNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters for updating a namespace resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ServiceBusNamespaceResource>> UpdateAsync(Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespacePatch patch, CancellationToken cancellationToken = default)
        {
            var lro = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(lro.Value, lro.GetRawResponse());
        }

        /// <summary>
        /// Creates or updates a namespace. Once created, this namespace's resource manifest is immutable. This operation is idempotent.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceBusNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters for updating a namespace resource. </param>
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
