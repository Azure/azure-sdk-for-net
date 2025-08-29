// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

public class SampleLiveTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    public async Task SimpleLiveDeploy()
    {
        await using NewTrycep test = SampleTests.CreateSimpleDeployTest();
        await test.ValidateAsync();
    }

    [Test]
    public async Task SimpleLiveContainerAppDeploy()
    {
        await using NewTrycep test = SampleTests.CreateSimpleContainerAppTest();
        await test.ValidateAsync();
    }

    [Test]
    public async Task SimpleLiveResourceGroupDeploy()
    {
        await using NewTrycep test = SampleTests.CreateSimpleResourceGroupTest();
        await test.ValidateAsync();
    }
}
