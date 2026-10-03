// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Automation.Tests;

public class BasicLiveAutomationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateAutomationAccount()
    {
        await using Trycep test = BasicAutomationTests.CreateAutomationAccountTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
