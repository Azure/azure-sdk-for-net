// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.TenantActivityLogAlerts.Tests;

public class BasicLiveTenantActivityLogAlertsTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateTenantActivityLogAlert()
    {
        await using Trycep test = BasicTenantActivityLogAlertsTests.CreateTenantActivityLogAlertTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
