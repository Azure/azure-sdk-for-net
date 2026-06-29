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
    public partial class NetAppElasticCapacityPoolData : TrackedResourceData { public NetAppElasticCapacityPoolData(AzureLocation location) : base(location) { Zones = new ChangeTrackingList<string>(); } internal NetAppElasticCapacityPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ElasticCapacityPoolProperties properties, ETag? eTag, IEnumerable<string> zones) : base(id, name, resourceType, systemData, tags, location) { Properties = properties; ETag = eTag; Zones = zones is null ? new ChangeTrackingList<string>() : new List<string>(zones); } public ElasticCapacityPoolProperties Properties { get; set; } public ETag? ETag { get; } public IList<string> Zones { get; } }
}
