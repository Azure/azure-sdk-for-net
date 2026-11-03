// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class ServiceGatewayResource
    {
        // 1.15.0 used an LRO; the current API completes synchronously, so either wait mode returns a completed native operation.
        /// <summary> Updates address locations using the current synchronous action. </summary>
        /// <remarks> The service action now completes synchronously; the returned operation is completed for either wait mode. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation> UpdateAddressLocationsAsync(WaitUntil waitUntil, ServiceGatewayUpdateAddressLocationsContent content, CancellationToken cancellationToken = default)
            => new NetworkArmOperation((await UpdateAddressLocationsAsync(content, cancellationToken).ConfigureAwait(false)).GetRawResponse());

        // Preserve the synchronous 1.15.0 LRO signature without inventing polling for the current synchronous endpoint.
        /// <summary> Updates address locations using the current synchronous action. </summary>
        /// <remarks> The service action now completes synchronously; the returned operation is completed for either wait mode. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation UpdateAddressLocations(WaitUntil waitUntil, ServiceGatewayUpdateAddressLocationsContent content, CancellationToken cancellationToken = default)
            => new NetworkArmOperation(UpdateAddressLocations(content, cancellationToken).GetRawResponse());

        // Preserve the asynchronous 1.15.0 operation result over the current synchronous services action.
        /// <summary> Updates services using the current synchronous action. </summary>
        /// <remarks> The service action now completes synchronously; the returned operation is completed for either wait mode. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation> UpdateServicesAsync(WaitUntil waitUntil, ServiceGatewayUpdateServicesContent content, CancellationToken cancellationToken = default)
            => new NetworkArmOperation((await UpdateServicesAsync(content, cancellationToken).ConfigureAwait(false)).GetRawResponse());

        // Preserve the synchronous 1.15.0 operation result and the native action's raw response.
        /// <summary> Updates services using the current synchronous action. </summary>
        /// <remarks> The service action now completes synchronously; the returned operation is completed for either wait mode. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation UpdateServices(WaitUntil waitUntil, ServiceGatewayUpdateServicesContent content, CancellationToken cancellationToken = default)
            => new NetworkArmOperation(UpdateServices(content, cancellationToken).GetRawResponse());
    }
}
