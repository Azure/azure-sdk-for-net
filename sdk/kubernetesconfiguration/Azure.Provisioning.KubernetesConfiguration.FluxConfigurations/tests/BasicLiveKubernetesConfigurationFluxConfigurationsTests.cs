// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.Tests;

public class BasicLiveKubernetesConfigurationFluxConfigurationsTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.kubernetesconfiguration")]
    [LiveOnly]
    public async Task CreateFluxConfiguration()
    {
        await using Trycep test = BasicKubernetesConfigurationFluxConfigurationsTests.CreateFluxConfigurationTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
