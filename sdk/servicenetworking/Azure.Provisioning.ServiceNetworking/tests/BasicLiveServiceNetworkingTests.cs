// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceNetworking.Tests;

public class BasicLiveServiceNetworkingTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateTrafficController()
    {
        await using Trycep test = BasicServiceNetworkingTests.CreateTrafficControllerTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
