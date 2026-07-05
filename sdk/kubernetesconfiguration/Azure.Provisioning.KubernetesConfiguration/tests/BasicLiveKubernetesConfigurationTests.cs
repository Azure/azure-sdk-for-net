// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.Tests;

public class BasicLiveKubernetesConfigurationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateClusterExtension()
    {
        await using Trycep test = BasicKubernetesConfigurationTests.CreateClusterExtensionTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
