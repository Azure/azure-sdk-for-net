// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceBus.Tests;

public class BasicLiveServiceBusTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.servicebus/servicebus-create-queue/main.bicep")]
    public async Task CreateServiceBusQueue()
    {
        await using Trycep test = BasicServiceBusTests.CreateServiceBusQueueTest();
        await test.SetupLiveCalls(this)
            .ValidateAsync();
    }
}
