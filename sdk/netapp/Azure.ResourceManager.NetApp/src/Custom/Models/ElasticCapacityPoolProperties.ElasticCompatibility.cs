// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ElasticCapacityPoolProperties { public ElasticCapacityPoolProperties(long size = default, ElasticServiceLevel serviceLevel = default, NetAppProvisioningState? provisioningState = default, ElasticEncryptionConfiguration encryption = default, double? totalThroughputMibps = default, ResourceIdentifier subnetResourceId = default, string currentZone = default, ElasticResourceAvailabilityStatus? availabilityStatus = default, ResourceIdentifier activeDirectoryConfigResourceId = default) { Size = size; ServiceLevel = serviceLevel; ProvisioningState = provisioningState; Encryption = encryption; TotalThroughputMibps = totalThroughputMibps; SubnetResourceId = subnetResourceId; CurrentZone = currentZone; AvailabilityStatus = availabilityStatus; ActiveDirectoryConfigResourceId = activeDirectoryConfigResourceId; } public long Size { get; set; } public ElasticServiceLevel ServiceLevel { get; set; } public NetAppProvisioningState? ProvisioningState { get; set; } public ElasticEncryptionConfiguration Encryption { get; set; } public double? TotalThroughputMibps { get; set; } public ResourceIdentifier SubnetResourceId { get; set; } public string CurrentZone { get; set; } public ElasticResourceAvailabilityStatus? AvailabilityStatus { get; set; } public ResourceIdentifier ActiveDirectoryConfigResourceId { get; set; } }
}
