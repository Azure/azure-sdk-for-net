// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DevHub.Tests;

public class BasicLiveDevHubTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateIacProfile()
    {
        await using Trycep test = BasicDevHubTests.CreateIacProfileTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
