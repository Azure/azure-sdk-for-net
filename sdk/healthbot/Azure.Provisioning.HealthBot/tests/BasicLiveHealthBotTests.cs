// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.HealthBot.Tests;

public class BasicLiveHealthBotTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateHealthBot()
    {
        await using Trycep test = BasicHealthBotTests.CreateHealthBotTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
