// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class VirtualHubResource
    {
        /// <summary> Gets the effective routes configured for the virtual hub. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation> GetEffectiveVirtualHubRoutesAsync(WaitUntil waitUntil, EffectiveRoutesContent content = default, CancellationToken cancellationToken = default)
            => new UntypedRouteOperation(await GetVirtualHubEffectiveRoutesAsync(waitUntil, content, cancellationToken).ConfigureAwait(false));

        /// <summary> Gets the effective routes configured for the virtual hub. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual ArmOperation GetEffectiveVirtualHubRoutes(WaitUntil waitUntil, EffectiveRoutesContent content = default, CancellationToken cancellationToken = default)
            => new UntypedRouteOperation(GetVirtualHubEffectiveRoutes(waitUntil, content, cancellationToken));

        /// <summary> Gets the inbound routes on a connection to the virtual hub. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation> GetInboundRoutesAsync(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken = default)
            => new UntypedRouteOperation(await GetVirtualHubInboundRoutesAsync(waitUntil, content, cancellationToken).ConfigureAwait(false));

        /// <summary> Gets the inbound routes on a connection to the virtual hub. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual ArmOperation GetInboundRoutes(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken = default)
            => new UntypedRouteOperation(GetVirtualHubInboundRoutes(waitUntil, content, cancellationToken));

        /// <summary> Gets the outbound routes on a connection to the virtual hub. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation> GetOutboundRoutesAsync(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken = default)
            => new UntypedRouteOperation(await GetVirtualHubOutboundRoutesAsync(waitUntil, content, cancellationToken).ConfigureAwait(false));

        /// <summary> Gets the outbound routes on a connection to the virtual hub. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual ArmOperation GetOutboundRoutes(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken = default)
            => new UntypedRouteOperation(GetVirtualHubOutboundRoutes(waitUntil, content, cancellationToken));

        // ArmOperation<T> derives from Operation<T>, not from the released untyped ArmOperation.
        private sealed class UntypedRouteOperation : ArmOperation
        {
            private readonly Operation _operation;

            public UntypedRouteOperation(Operation operation) => _operation = operation;

            public override string Id => _operation.Id;
            public override bool HasCompleted => _operation.HasCompleted;
            public override Response GetRawResponse() => _operation.GetRawResponse();
            public override RehydrationToken? GetRehydrationToken() => _operation.GetRehydrationToken();
            public override Response UpdateStatus(CancellationToken cancellationToken = default)
                => _operation.UpdateStatus(cancellationToken);
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
                => _operation.UpdateStatusAsync(cancellationToken);
            public override Response WaitForCompletionResponse(CancellationToken cancellationToken = default)
                => _operation.WaitForCompletionResponse(cancellationToken);
            public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
                => _operation.WaitForCompletionResponse(pollingInterval, cancellationToken);
            public override Response WaitForCompletionResponse(DelayStrategy delayStrategy, CancellationToken cancellationToken = default)
                => _operation.WaitForCompletionResponse(delayStrategy, cancellationToken);
            public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
                => _operation.WaitForCompletionResponseAsync(cancellationToken);
            public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
                => _operation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);
            public override ValueTask<Response> WaitForCompletionResponseAsync(DelayStrategy delayStrategy, CancellationToken cancellationToken = default)
                => _operation.WaitForCompletionResponseAsync(delayStrategy, cancellationToken);
        }
    }
}
