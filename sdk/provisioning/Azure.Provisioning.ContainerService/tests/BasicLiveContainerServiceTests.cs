// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ContainerService.Tests;

public class BasicLiveContainerServiceTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.kubernetes/aks/main.bicep")]
    public async Task CreateAksCluster()
    {
        await using Trycep test = BasicContainerServiceTests.CreateAksClusterTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }
}
