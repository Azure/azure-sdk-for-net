// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.FrontDoor.Tests;

public class BasicLiveFrontDoorTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/front-door-create-basic/main.bicep")]
    [LiveOnly]
    public async Task CreateBasicFrontDoor()
    {
        await using Trycep test = BasicFrontDoorTests.CreateBasicFrontDoorTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/front-door-create-redirect/main.bicep")]
    [LiveOnly]
    public async Task CreateFrontDoorRedirect()
    {
        await using Trycep test = BasicFrontDoorTests.CreateFrontDoorRedirectTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
