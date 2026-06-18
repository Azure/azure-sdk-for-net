// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ConnectionMonitorResource type. </summary>
    public partial class ConnectionMonitorResource
    {
        /// <summary> Invokes the QueryAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ConnectionMonitorQueryResult>> QueryAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Query compatibility operation. </summary>
        public virtual ArmOperation<ConnectionMonitorQueryResult> Query(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the StartAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Start compatibility operation. </summary>
        public virtual ArmOperation Start(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
    }
}
