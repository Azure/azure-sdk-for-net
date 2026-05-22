// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    [CodeGenSuppress("GetJitNetworkAccessPoliciesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetJitNetworkAccessPolicies", typeof(CancellationToken))]
    public partial class MockableSecurityCenterResourceGroupResource
    {
    }
}
