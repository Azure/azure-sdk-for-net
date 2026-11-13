// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.IotHub.Tests;

public class BasicLiveIotHubTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description(
        "Azure Quickstart Template: https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.devices/iothub-device-provisioning/main.bicep; " +
        "Microsoft Learn: https://learn.microsoft.com/azure/iot-hub/create-hub")]
    [LiveOnly]
    public async Task CreateIotHub()
    {
        await using Trycep test = BasicIotHubTests.CreateIotHubTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
