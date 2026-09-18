// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.ExtensionTypes.Tests;

public class BasicKubernetesConfigurationExtensionTypesTests
{
    internal static Trycep ReferenceExtensionTypeTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KubernetesConfigurationExtensionTypesBasic
                Infrastructure infra = new();

                LocationExtensionType extensionType =
                    LocationExtensionType.FromExisting(
                        nameof(extensionType),
                        LocationExtensionType.ResourceVersions.V2024_11_01_PREVIEW);
                extensionType.Name = "eastus/microsoft.flux";
                infra.Add(extensionType);
                infra.Add(new ProvisioningOutput("extensionTypeId", typeof(string)) { Value = extensionType.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.kubernetesconfiguration")]
    public async Task ReferenceExtensionType()
    {
        await using Trycep test = ReferenceExtensionTypeTest();
        test.Compare(
            """
            resource extensionType 'Microsoft.KubernetesConfiguration/locations/extensionTypes@2024-11-01-preview' existing = {
              name: 'eastus/microsoft.flux'
            }

            output extensionTypeId string = extensionType.id
            """);
    }
}
