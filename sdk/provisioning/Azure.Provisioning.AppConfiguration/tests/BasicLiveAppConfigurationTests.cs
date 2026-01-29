// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppConfiguration.Tests;

public class BasicLiveAppConfigurationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.appconfiguration/app-configuration-store-ff/main.bicep")]
    [LiveOnly]
    public async Task CreateAppConfigAndFeatureFlag()
    {
        await using Trycep test = BasicAppConfigurationTests.CreateAppConfigAndFeatureFlagTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
