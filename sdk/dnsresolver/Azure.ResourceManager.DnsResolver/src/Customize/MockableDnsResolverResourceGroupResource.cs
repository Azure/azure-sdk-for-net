// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.DnsResolver.Mocking
{
    // TO-DO: this is a workaround as we don't support partial resource for TypeSpec input. We should remove this file after we move to MPG.
    [CodeGenSuppress("GetDnsForwardingRulesetsByVirtualNetwork", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsForwardingRulesetsByVirtualNetworkAsync", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolverPoliciesByVirtualNetwork", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolverPoliciesByVirtualNetworkAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolversByVirtualNetwork", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDnsResolversByVirtualNetworkAsync", typeof(string), typeof(int?), typeof(CancellationToken))]
    public partial class MockableDnsResolverResourceGroupResource : ArmResource
    {
    }
}
