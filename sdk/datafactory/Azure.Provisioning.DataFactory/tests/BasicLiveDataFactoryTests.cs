// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DataFactory.Tests;

public class BasicLiveDataFactoryTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.datafactory/data-factory-v2-blob-to-blob-copy/main.bicep")]
    [LiveOnly]
    public async Task CreateDataFactoryWithLinkedService()
    {
        await using Trycep test = BasicDataFactoryTests.CreateDataFactoryWithLinkedServiceTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .DeployAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.datafactory/data-factory-v2-git-config-managed-vnet/main.bicep")]
    [LiveOnly]
    public async Task CreateDataFactoryWithGitConfigAndManagedVnet()
    {
        await using Trycep test = BasicDataFactoryTests.CreateDataFactoryWithGitConfigAndManagedVnetTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .DeployAsync();
    }
}
