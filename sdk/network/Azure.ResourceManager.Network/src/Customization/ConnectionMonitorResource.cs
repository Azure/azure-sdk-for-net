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
        /// <summary> Invokes the QueryAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This legacy query operation is not supported by the current connection monitor API.")]
        public virtual Task<ArmOperation<ConnectionMonitorQueryResult>> QueryAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the Query compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This legacy query operation is not supported by the current connection monitor API.")]
        public virtual ArmOperation<ConnectionMonitorQueryResult> Query(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the StartAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the Start compatibility operation. </summary>
        public virtual ArmOperation Start(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
