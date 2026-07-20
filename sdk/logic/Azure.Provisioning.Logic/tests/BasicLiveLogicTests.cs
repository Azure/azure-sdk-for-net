// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Logic.Tests;

public class BasicLiveLogicTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.logic/integrationaccounts?pivots=deployment-language-bicep")]
    [LiveOnly]
    public async Task CreateIntegrationAccount()
    {
        await using Trycep test = BasicLogicTests.CreateIntegrationAccountTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
