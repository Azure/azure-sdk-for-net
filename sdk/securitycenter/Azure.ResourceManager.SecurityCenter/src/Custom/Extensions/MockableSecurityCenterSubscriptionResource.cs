// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    // Suppress malformed generated JIT policy forwarding helpers; the collection-level APIs remain generated.
    [CodeGenSuppress("GetAllowedConnectionsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAllowedConnections", typeof(CancellationToken))]
    [CodeGenSuppress("GetDiscoveredSecuritySolutionsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetDiscoveredSecuritySolutions", typeof(CancellationToken))]
    [CodeGenSuppress("GetExternalSecuritySolutionsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetExternalSecuritySolutions", typeof(CancellationToken))]
    [CodeGenSuppress("GetJitNetworkAccessPoliciesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetJitNetworkAccessPolicies", typeof(CancellationToken))]
    [CodeGenSuppress("GetMdeOnboardingsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetMdeOnboardings", typeof(CancellationToken))]
    [CodeGenSuppress("GetSecuritySolutionsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetSecuritySolutions", typeof(CancellationToken))]
    [CodeGenSuppress("GetTopologiesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetTopologies", typeof(CancellationToken))]
    public partial class MockableSecurityCenterSubscriptionResource
    {
    }
}
