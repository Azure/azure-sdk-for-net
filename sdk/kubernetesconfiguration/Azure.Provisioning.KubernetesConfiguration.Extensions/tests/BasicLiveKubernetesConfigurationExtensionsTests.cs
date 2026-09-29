// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.Extensions.Tests;

public class BasicLiveKubernetesConfigurationExtensionsTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateClusterExtension()
    {
        await using Trycep test = BasicKubernetesConfigurationExtensionsTests.CreateClusterExtensionTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
