// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticCapacityPoolResource : ArmResource { protected NetAppElasticCapacityPoolResource() { } internal NetAppElasticCapacityPoolResource(ArmClient client, ResourceIdentifier id) : base(client, id) { TryGetApiVersion(ResourceType, out string netAppElasticCapacityPoolApiVersion); _elasticCapacityPoolsClientDiagnostics = new Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.NetApp", ResourceType.Namespace, Diagnostics); _elasticCapacityPoolsRestClient = new ElasticCapacityPools(_elasticCapacityPoolsClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, netAppElasticCapacityPoolApiVersion ?? "2026-08-15-preview"); } }
}
