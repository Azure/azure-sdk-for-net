// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.RecoveryServices.Tests;

public class BasicLiveRecoveryServicesTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.recoveryservices/2026-05-01/vaults")]
    [LiveOnly]
    public async Task CreateVault()
    {
        await using Trycep test = BasicRecoveryServicesTests.CreateVaultTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
