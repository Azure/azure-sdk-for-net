// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.Tests;

public class BasicLiveKubernetesConfigurationPrivateLinkScopesTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreatePrivateLinkScope()
    {
        await using Trycep test = BasicKubernetesConfigurationPrivateLinkScopesTests.CreatePrivateLinkScopeTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
