// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ContainerRegistry.Tests;

public class BasicLiveContainerRegistryTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.containerregistry/container-registry/main.bicep")]
    [LiveOnly]
    public async Task CreateContainerRegistry()
    {
        await using Trycep test = BasicContainerRegistryTests.CreateContainerRegistryTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
