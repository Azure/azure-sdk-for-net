// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceGroups.Tests;

public class BasicServiceGroupsTests
{
    internal static Trycep CreateServiceGroupTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ServiceGroupsBasic
                Infrastructure infra = new()
                {
                    TargetScope = DeploymentScope.Tenant,
                };

                ServiceGroup group =
                    new(nameof(group), ServiceGroup.ResourceVersions.V2026_08_01)
                    {
                        Name = "sample-service-group",
                        Properties = new ServiceGroupProperties
                        {
                            DisplayName = "Sample service group",
                            AttributesCriticality = 2,
                        },
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(group);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.management/2026-08-01/servicegroups?pivots=deployment-language-bicep")]
    public async Task CreateServiceGroup()
    {
        await using Trycep test = CreateServiceGroupTest();
        test.Compare(
            """
            targetScope = 'tenant'

            resource group 'Microsoft.Management/serviceGroups@2026-08-01' = {
              name: 'sample-service-group'
              properties: {
                attributes: {
                  criticality: 2
                }
                displayName: 'Sample service group'
              }
              tags: {
                environment: 'test'
              }
            }
            """);
    }
}
