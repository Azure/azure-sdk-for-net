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
    public partial class NetAppElasticAccountPatch { public NetAppElasticAccountPatch(ManagedServiceIdentity identity = default, IDictionary<string, string> tags = default, ElasticEncryption elasticAccountUpdateEncryption = default) { Identity = identity; Tags = tags ?? new ChangeTrackingDictionary<string, string>(); ElasticAccountUpdateEncryption = elasticAccountUpdateEncryption; } public ManagedServiceIdentity Identity { get; set; } public IDictionary<string, string> Tags { get; } public ElasticEncryption ElasticAccountUpdateEncryption { get; set; } }
}
