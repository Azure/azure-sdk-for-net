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
    /// <summary> Compatibility declaration for the ConnectionMonitorCollection type. </summary>
    public partial class ConnectionMonitorCollection
    {
        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ConnectionMonitorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorCreateOrUpdateContent content, string migrate, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<ConnectionMonitorResource> CreateOrUpdate(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorCreateOrUpdateContent content, string migrate, CancellationToken cancellationToken) => default;
    }
}
