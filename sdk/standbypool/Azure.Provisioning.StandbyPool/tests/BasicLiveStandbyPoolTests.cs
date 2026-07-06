// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.StandbyPool.Tests;

public class BasicLiveStandbyPoolTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateStandbyVirtualMachinePool()
    {
        await using Trycep test = BasicStandbyPoolTests.CreateStandbyVirtualMachinePoolTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
