// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ApiManagement.Tests;

public class BasicLiveApiManagementTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.apimanagement/api-management-create-with-msi/main.bicep")]
    [LiveOnly]
    public async Task CreateApiManagementWithMsi()
    {
        await using Trycep test = BasicApiManagementTests.CreateApiManagementWithMsiTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.apimanagement/api-management-create-all-resources/azuredeploy.json")]
    [LiveOnly]
    public async Task CreateApiManagementWithAllResources()
    {
        await using Trycep test = BasicApiManagementTests.CreateApiManagementWithAllResourcesTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
