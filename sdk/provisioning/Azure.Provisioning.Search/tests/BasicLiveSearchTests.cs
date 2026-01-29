// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Search.Tests;

public class BasicLiveSearchTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.search/azure-search-create/main.bicep")]
    [LiveOnly]
    public async Task CreateSearchService()
    {
        await using Trycep test = BasicSearchTests.CreateSearchServiceTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .DeployAsync();
    }
}
