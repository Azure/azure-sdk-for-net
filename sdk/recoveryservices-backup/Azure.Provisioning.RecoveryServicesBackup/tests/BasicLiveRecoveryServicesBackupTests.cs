// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.RecoveryServicesBackup.Tests;

public class BasicLiveRecoveryServicesBackupTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.recoveryservices/vaults/backuppolicies")]
    [LiveOnly]
    public async Task CreateVmBackupPolicy()
    {
        await using Trycep test = BasicRecoveryServicesBackupTests.CreateVmBackupPolicyTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
