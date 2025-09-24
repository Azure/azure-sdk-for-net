// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppService.Tests;

public class BasicLiveAppServiceTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.web/function-app-create-dynamic/main.bicep")]
    [LiveOnly]
    public async Task CreateBasicFunctionApp()
    {
        await using Trycep test = BasicAppServiceTests.CreateBasicFunctionAppTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
