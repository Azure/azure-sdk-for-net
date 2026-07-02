// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.BotService.Tests;

public class BasicLiveBotServiceTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateBot()
    {
        await using Trycep test = BasicBotServiceTests.CreateBotTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
