// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SecurityCenter.Tests;

public class BasicLiveSecurityCenterTests : ProvisioningTestBase
{
    public BasicLiveSecurityCenterTests(bool async)
        : base(async) { }

    [Test]
    [LiveOnly]
    public async Task CreateDefenderPricing()
    {
        await using Trycep test = BasicSecurityCenterTests.CreateDefenderPricingTest();
        await test.SetupLiveCalls(this).Lint().ValidateAsync();
    }
}
