// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ResourceConnector.Tests;

public class BasicResourceConnectorTests
{
    internal static Trycep CreateApplianceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ResourceConnectorBasic
                Infrastructure infra = new();

                ResourceConnectorAppliance appliance =
                    new(nameof(appliance), ResourceConnectorAppliance.ResourceVersions.V2022_10_27)
                    {
                        Name = "my-appliance",
                        Distro = ApplianceDistro.AksEdge,
                        InfrastructureConfigProvider = ApplianceProvider.VMware,
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned,
                        },
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(appliance);

                infra.Add(new ProvisioningOutput("applianceId", typeof(string)) { Value = appliance.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateAppliance()
    {
        await using Trycep test = CreateApplianceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource appliance 'Microsoft.ResourceConnector/appliances@2022-10-27' = {
              name: 'my-appliance'
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                distro: 'AKSEdge'
                infrastructureConfig: {
                  provider: 'VMWare'
                }
              }
              tags: {
                environment: 'test'
              }
            }

            output applianceId string = appliance.id
            """);
    }
}
