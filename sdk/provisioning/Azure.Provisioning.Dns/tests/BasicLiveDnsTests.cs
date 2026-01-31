// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Dns.Tests;

internal class BasicLiveDnsTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/azure-dns-new-zone/main.bicep")]
    [LiveOnly]
    public async Task CreateAzureDnsNewZone()
    {
        await using Trycep test = BasicDnsTests.CreateAzureDnsNewZoneTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
