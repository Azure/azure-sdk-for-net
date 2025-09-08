// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.EventHubs.Tests;

public class BasicLiveEventHubsTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.eventhub/event-hubs-create-event-hub-and-consumer-group/main.bicep")]
    [LiveOnly]
    public async Task CreateEventHubAndConsumerGroup()
    {
        await using Trycep test = BasicEventHubsTests.CreateEventHubAndConsumerGroupTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
