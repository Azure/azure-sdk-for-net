// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.OperationalInsights.Tests;

public class BasicLiveOperationalInsightsTests(bool async)
    : ProvisioningTestBase(async/*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    public async Task CreateWorkspace()
    {
        await using Trycep test = BasicOperationalInsightsTests.CreateWorkspaceTest();
        await test.SetupLiveCalls(this)
            .DeployAsync();
    }
}
