// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceFabric.Tests;

public class BasicLiveServiceFabricTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateApplicationType()
    {
        await using Trycep test = BasicServiceFabricTests.CreateApplicationTypeTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
