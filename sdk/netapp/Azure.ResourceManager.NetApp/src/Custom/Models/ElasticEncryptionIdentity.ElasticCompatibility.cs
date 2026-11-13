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
    public partial class ElasticEncryptionIdentity { public ElasticEncryptionIdentity(string principalId = default, ResourceIdentifier userAssignedIdentity = default, string federatedClientId = default) { PrincipalId = principalId; UserAssignedIdentity = userAssignedIdentity; FederatedClientId = federatedClientId; } public string PrincipalId { get; set; } public ResourceIdentifier UserAssignedIdentity { get; set; } public string FederatedClientId { get; set; } }
}
