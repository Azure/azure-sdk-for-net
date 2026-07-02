// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DurableTask
{
    public partial class DurableTaskSchedulerResource
    {
        // The previous customization renaming of the SchedulerPrivateLink and PrivateEndpointConnection have those methods with the old names.
        // After the renaming from the Spec, the new names are GetDurableTaskSchedulerPrivateLinkResources and GetDurableTaskPrivateEndpointConnections.
        // We are keeping them for backward compatibility, but they are marked as EditorBrowsableState.Never to hide them from intellisense.
        /// <summary> Gets a collection of SchedulerPrivateLinkResources in the <see cref="DurableTaskSchedulerResource"/>. </summary>
        /// <returns> An object representing collection of SchedulerPrivateLinkResources and their operations over a DurableTaskSchedulerPrivateLinkResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DurableTaskSchedulerPrivateLinkResourceCollection GetSchedulerPrivateLinkResources()
            => GetDurableTaskSchedulerPrivateLinkResources();

        /// <summary> Gets a collection of PrivateEndpointConnections in the <see cref="DurableTaskSchedulerResource"/>. </summary>
        /// <returns> An object representing collection of PrivateEndpointConnections and their operations over a DurableTaskPrivateEndpointConnectionResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DurableTaskPrivateEndpointConnectionCollection GetPrivateEndpointConnections()
            => GetDurableTaskPrivateEndpointConnections();

        /// <summary> Get a private link resource for the durable task scheduler. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link associated with the Azure resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateLinkResourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="privateLinkResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<DurableTaskSchedulerPrivateLinkResource>> GetSchedulerPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
            => await GetDurableTaskSchedulerPrivateLinkResourceAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);

        /// <summary> Get a private link resource for the durable task scheduler. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link associated with the Azure resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateLinkResourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="privateLinkResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DurableTaskSchedulerPrivateLinkResource> GetSchedulerPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
            => GetDurableTaskSchedulerPrivateLinkResource(privateLinkResourceName, cancellationToken);

        /// <summary> Get a private endpoint connection for the durable task scheduler. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection associated with the Azure resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<DurableTaskPrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => await GetDurableTaskPrivateEndpointConnectionAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);

        /// <summary> Get a private endpoint connection for the durable task scheduler. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection associated with the Azure resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DurableTaskPrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
            => GetDurableTaskPrivateEndpointConnection(privateEndpointConnectionName, cancellationToken);
    }
}
