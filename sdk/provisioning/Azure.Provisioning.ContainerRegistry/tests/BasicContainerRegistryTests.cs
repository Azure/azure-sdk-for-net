// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ContainerRegistry.Tests;

public class BasicContainerRegistryTests
{
    internal static Trycep CreateContainerRegistryTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ContainerRegistryBasic
                Infrastructure infra = new();

                ContainerRegistryService registry =
                    new(nameof(registry), ContainerRegistryService.ResourceVersions.V2023_07_01)
                    {
                        Sku = new ContainerRegistrySku { Name = ContainerRegistrySkuName.Standard },
                        IsAdminUserEnabled = false,
                        Tags = { { "displayName", "ContainerRegistry" } }
                    };
                registry.Tags.Add("container.registry", registry.Name);
                infra.Add(registry);

                infra.Add(new ProvisioningOutput("registryLoginServer", typeof(string)) { Value = registry.LoginServer });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.containerregistry/container-registry/main.bicep")]
    public async Task CreateContainerRegistry()
    {
        await using Trycep test = CreateContainerRegistryTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource registry 'Microsoft.ContainerRegistry/registries@2023-07-01' = {
              name: take('registry${uniqueString(resourceGroup().id)}', 50)
              location: location
              sku: {
                name: 'Standard'
              }
              properties: {
                adminUserEnabled: false
              }
              tags: {
                displayName: 'ContainerRegistry'
                'container.registry': take('registry${uniqueString(resourceGroup().id)}', 50)
              }
            }

            output registryLoginServer string = registry.properties.loginServer
            """);
    }
}
