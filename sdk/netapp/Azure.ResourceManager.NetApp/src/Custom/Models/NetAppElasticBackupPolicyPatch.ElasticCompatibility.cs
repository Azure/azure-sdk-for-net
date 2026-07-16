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
    public partial class NetAppElasticBackupPolicyPatch { public NetAppElasticBackupPolicyPatch(IDictionary<string, string> tags = default, NetAppElasticBackupPolicyPatchProperties properties = default) { Tags = tags ?? new ChangeTrackingDictionary<string, string>(); Properties = properties; } public IDictionary<string, string> Tags { get; } public NetAppElasticBackupPolicyPatchProperties Properties { get; set; } }
}
