// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Monitor.Tests;

public class BasicLiveMonitorTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.insights/insights-alertrules-servicehealth/main.bicep")]
    [LiveOnly]
    public async Task CreateServiceHealthAlert()
    {
        await using Trycep test = BasicMonitorTests.CreateServiceHealthAlertTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
