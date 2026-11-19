// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SiteManager.Tests;

public class BasicSiteManagerTests
{
    internal static Trycep CreateSiteTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SiteManagerSiteBasic
                Infrastructure infra = new();

                EdgeSite site =
                    new(nameof(site), EdgeSite.ResourceVersions.V2025_06_01)
                    {
                        Name = "example-site",
                        Properties = new EdgeSiteProperties
                        {
                            DisplayName = "Example site",
                            Description = "A site managed with Azure Provisioning.",
                            Labels = { ["environment"] = "test" },
                            SiteAddress = new EdgeSiteAddressProperties
                            {
                                City = "Seattle",
                                StateOrProvince = "WA",
                                Country = "US",
                                PostalCode = "98101",
                            },
                        },
                    };
                infra.Add(site);

                infra.Add(new ProvisioningOutput("siteName", typeof(string)) { Value = site.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = site.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.edge/2025-06-01/sites")]
    public async Task CreateSite()
    {
        await using Trycep test = CreateSiteTest();
        test.Compare(
            """
            resource site 'Microsoft.Edge/sites@2025-06-01' = {
              name: 'example-site'
              properties: {
                description: 'A site managed with Azure Provisioning.'
                displayName: 'Example site'
                labels: {
                  environment: 'test'
                }
                siteAddress: {
                  city: 'Seattle'
                  country: 'US'
                  postalCode: '98101'
                  stateOrProvince: 'WA'
                }
              }
            }

            output siteName string = 'example-site'

            output resourceId string = site.id
            """);
    }
}
