// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Kubernetes.Tests;

public class BasicLiveKubernetesTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateConnectedCluster()
    {
        await using Trycep test = BasicKubernetesTests.CreateConnectedClusterTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
