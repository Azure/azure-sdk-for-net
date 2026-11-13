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
    public partial class ElasticKeyVaultProperties { public ElasticKeyVaultProperties(Uri keyVaultUri = default, string keyName = default, ResourceIdentifier keyVaultResourceId = default, ElasticKeyVaultStatus? status = default) { KeyVaultUri = keyVaultUri; KeyName = keyName; KeyVaultResourceId = keyVaultResourceId; Status = status; } public Uri KeyVaultUri { get; set; } public string KeyName { get; set; } public ResourceIdentifier KeyVaultResourceId { get; set; } public ElasticKeyVaultStatus? Status { get; set; } }
}
