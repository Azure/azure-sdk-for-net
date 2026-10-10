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
    public partial class ElasticExportPolicyRule { public ElasticExportPolicyRule(int? ruleIndex = default, ElasticUnixAccessRule? unixAccessRule = default, ElasticNfsv3Access? nfsv3 = default, ElasticNfsv4Access? nfsv4 = default, IEnumerable<string> allowedClients = default, ElasticRootAccess? rootAccess = default) { RuleIndex = ruleIndex; UnixAccessRule = unixAccessRule; Nfsv3 = nfsv3; Nfsv4 = nfsv4; AllowedClients = allowedClients is null ? new ChangeTrackingList<string>() : new List<string>(allowedClients); RootAccess = rootAccess; } public int? RuleIndex { get; set; } public ElasticUnixAccessRule? UnixAccessRule { get; set; } public ElasticNfsv3Access? Nfsv3 { get; set; } public ElasticNfsv4Access? Nfsv4 { get; set; } public IList<string> AllowedClients { get; } public ElasticRootAccess? RootAccess { get; set; } }
}
