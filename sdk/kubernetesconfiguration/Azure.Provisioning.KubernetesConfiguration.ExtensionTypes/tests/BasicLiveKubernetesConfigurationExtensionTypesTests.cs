// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.Tests;

public class BasicLiveKubernetesConfigurationExtensionTypesTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.kubernetesconfiguration")]
    [LiveOnly]
    public async Task ReferenceExtensionType()
    {
        await using Trycep test = BasicKubernetesConfigurationExtensionTypesTests.ReferenceExtensionTypeTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
