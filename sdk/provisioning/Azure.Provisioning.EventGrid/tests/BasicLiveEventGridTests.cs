// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.EventGrid.Tests;

public class BasicLiveEventGridTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.eventgrid/event-grid-subscription-and-storage/main.bicep")]
    [LiveOnly]
    public async Task CreateEventGridForBlobs()
    {
        await using Trycep test = BasicEventGridTests.CreateEventGridForBlobsTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
