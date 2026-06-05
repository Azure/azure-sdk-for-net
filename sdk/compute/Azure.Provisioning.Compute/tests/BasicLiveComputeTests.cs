// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Compute.Tests;

public class BasicLiveComputeTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.compute/availability-set-create-3FDs-20UDs")]
    [LiveOnly]
    public async Task CreateAvailabilitySet()
    {
        await using Trycep test = BasicComputeTests.CreateAvailabilitySetTest();
        await test.SetupLiveCalls(this).Lint().ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.compute/vm-simple-windows/main.bicep")]
    [LiveOnly]
    public async Task CreateSimpleWindowsVm()
    {
        await using Trycep test = BasicComputeTests.CreateSimpleWindowsVmTest();
        await test.SetupLiveCalls(this).Lint().ValidateAsync();
    }
}
