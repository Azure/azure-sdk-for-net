// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.PrivateDns.Tests;

public class BasicLivePrivateDnsTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/private-dns-zone/main.bicep")]
    [LiveOnly]
    public async Task PrivateDnsZoneBasic()
    {
        await using Trycep test = BasicPrivateDnsTests.CreatePrivateDnsZoneBasic();
        await test.SetupLiveCalls(this)
            .Lint()
            .DeployAsync();
    }
}
