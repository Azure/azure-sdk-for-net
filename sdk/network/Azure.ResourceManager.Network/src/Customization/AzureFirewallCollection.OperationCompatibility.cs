// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

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
    public partial class AzureFirewallCollection
    {
        [global::Azure.Core.ForwardsClientCalls]
        public virtual Task<ArmOperation<AzureFirewallResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string azureFirewallName, AzureFirewallData data, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, azureFirewallName, data, createAfcControlPlane: default, cancellationToken);

        [global::Azure.Core.ForwardsClientCalls]
        public virtual ArmOperation<AzureFirewallResource> CreateOrUpdate(WaitUntil waitUntil, string azureFirewallName, AzureFirewallData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, azureFirewallName, data, createAfcControlPlane: default, cancellationToken);
    }
}
