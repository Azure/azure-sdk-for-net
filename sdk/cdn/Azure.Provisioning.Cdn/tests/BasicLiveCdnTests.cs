// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Cdn.Tests;

public class BasicLiveCdnTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cdn/cdn-with-custom-origin/main.bicep")]
    [LiveOnly]
    public async Task CreateCdnWithCustomOrigin()
    {
        await using Trycep test = BasicCdnTests.CreateCdnWithCustomOriginTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cdn/front-door-standard-premium/main.bicep")]
    [LiveOnly]
    public async Task CreateFrontDoorStandardPremium()
    {
        await using Trycep test = BasicCdnTests.CreateFrontDoorStandardPremiumTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
