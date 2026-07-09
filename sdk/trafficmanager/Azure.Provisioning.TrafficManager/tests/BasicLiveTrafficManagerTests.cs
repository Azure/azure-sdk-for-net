// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.TrafficManager.Tests;

public class BasicLiveTrafficManagerTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateTrafficManagerProfile()
    {
        await using Trycep test = BasicTrafficManagerTests.CreateTrafficManagerProfileTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
