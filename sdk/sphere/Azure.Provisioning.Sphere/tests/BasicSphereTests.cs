// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Sphere.Tests;

public class BasicSphereTests
{
    internal static Trycep CreateCatalogTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SphereCatalogBasic
                Infrastructure infra = new();

                SphereCatalog catalog =
                    new(nameof(catalog), SphereCatalog.ResourceVersions.V2024_04_01)
                    {
                        Name = "my-catalog",
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(catalog);

                infra.Add(new ProvisioningOutput("catalogId", typeof(string)) { Value = catalog.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.azuresphere/2024-04-01/catalogs")]
    public async Task CreateCatalog()
    {
        await using Trycep test = CreateCatalogTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource catalog 'Microsoft.AzureSphere/catalogs@2024-04-01' = {
              name: 'my-catalog'
              location: location
              tags: {
                environment: 'test'
              }
            }

            output catalogId string = catalog.id
            """);
    }
}
