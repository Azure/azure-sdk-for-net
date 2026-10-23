// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class ConnectionMonitorResource
    {
        // These entry points already threw in 1.15.0 after retirement in API version 2024-07-01.
        // Preserve their released signatures and behavior; TypeSpec has no corresponding query/start operations.
        /// <summary> Invokes the QueryAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This legacy query operation is not supported by the current connection monitor API.")]
        public virtual Task<ArmOperation<ConnectionMonitorQueryResult>> QueryAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => throw new NotSupportedException($"The {nameof(QueryAsync)} method has been deprecated for this resource type as of version 2024-07-01.");
        /// <summary> Invokes the Query compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This legacy query operation is not supported by the current connection monitor API.")]
        public virtual ArmOperation<ConnectionMonitorQueryResult> Query(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => throw new NotSupportedException($"The {nameof(Query)} method has been deprecated for this resource type as of version 2024-07-01.");
        /// <summary> Invokes the StartAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => throw new NotSupportedException($"The {nameof(StartAsync)} method has been deprecated for this resource type as of version 2024-07-01.");
        /// <summary> Invokes the Start compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Start(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => throw new NotSupportedException($"The {nameof(Start)} method has been deprecated for this resource type as of version 2024-07-01.");
    }
}
