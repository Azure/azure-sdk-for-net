// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    [CodeGenSuppress("GetDnsResolvers", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolversAsync", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsForwardingRulesets", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsForwardingRulesetsAsync", typeof(string), typeof(int?), typeof(CancellationToken))]
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
    }
}
