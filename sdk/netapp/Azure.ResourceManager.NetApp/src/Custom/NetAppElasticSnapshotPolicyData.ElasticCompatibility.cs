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
    public partial class NetAppElasticSnapshotPolicyData : TrackedResourceData { public NetAppElasticSnapshotPolicyData(AzureLocation location) : base(location) { } internal NetAppElasticSnapshotPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ElasticSnapshotPolicyProperties properties, ETag? eTag) : base(id, name, resourceType, systemData, tags, location) { Properties = properties; ETag = eTag; } public ElasticSnapshotPolicyProperties Properties { get; set; } public ETag? ETag { get; } }
}
