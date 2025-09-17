// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.WebPubSub.Tests;

public class BasicLiveWebPubSubTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.web/azure-web-pubsub/main.bicep")]
    [LiveOnly]
    public async Task CreateSimpleWebPubSub()
    {
        await using Trycep test = BasicWebPubSubTests.CreateSimpleWebPubSubTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
