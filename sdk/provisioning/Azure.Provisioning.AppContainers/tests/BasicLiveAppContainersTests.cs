// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppContainers.Tests;

public class BasicLiveAppContainersTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.app/container-app-create/main.bicep")]
    [LiveOnly]
    public async Task CreateContainerApp()
    {
        await using Trycep test = BasicAppContainersTests.CreateContainerAppTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
