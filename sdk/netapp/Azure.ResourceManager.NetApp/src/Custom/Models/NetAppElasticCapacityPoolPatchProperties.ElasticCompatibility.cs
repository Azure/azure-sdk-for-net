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
    public partial class NetAppElasticCapacityPoolPatchProperties { public NetAppElasticCapacityPoolPatchProperties(long? size = default, ElasticEncryptionConfiguration encryption = default, ResourceIdentifier activeDirectoryConfigResourceId = default) { Size = size; Encryption = encryption; ActiveDirectoryConfigResourceId = activeDirectoryConfigResourceId; } public long? Size { get; set; } public ElasticEncryptionConfiguration Encryption { get; set; } public ResourceIdentifier ActiveDirectoryConfigResourceId { get; set; } }
}
