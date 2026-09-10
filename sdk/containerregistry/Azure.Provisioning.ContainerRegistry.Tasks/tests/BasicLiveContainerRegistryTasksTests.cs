// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ContainerRegistry.Tasks.Tests;

public class BasicLiveContainerRegistryTasksTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.resources/deployment-script-azcli-acr-build/main.bicep")]
    [LiveOnly]
    public async Task CreateTask()
    {
        await using Trycep test = BasicContainerRegistryTasksTests.CreateTaskTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
