// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Security.Mocking
{
    [CodeGenSuppress("GetJitNetworkAccessPoliciesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetJitNetworkAccessPolicies", typeof(CancellationToken))]
    public partial class MockableSecuritySubscriptionResource
    {
    }
}
