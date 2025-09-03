// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

public class SampleLiveTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task SimpleLiveDeploy()
    {
        await using Trycep test = SampleTests.CreateSimpleDeployTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [LiveOnly]
    public async Task SimpleLiveContainerAppDeploy()
    {
        await using Trycep test = SampleTests.CreateSimpleContainerAppTest();
        await test.SetupLiveCalls(this)
            .Lint(ignore: ["no-unused-params", "BCP029"])
            .ValidateAsync();
    }

    [Test]
    [LiveOnly]
    public async Task SimpleLiveResourceGroupDeploy()
    {
        await using Trycep test = SampleTests.CreateSimpleResourceGroupTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
