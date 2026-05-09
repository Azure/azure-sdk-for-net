// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceNetworking.Tests;

public class BasicServiceNetworkingTests
{
    internal static Trycep CreateTrafficControllerTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ServiceNetworkingBasic
                Infrastructure infra = new();

                TrafficController controller =
                    new(nameof(controller), TrafficController.ResourceVersions.V2025_01_01)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(controller);

                TrafficControllerFrontend frontend =
                    new(nameof(frontend), TrafficControllerFrontend.ResourceVersions.V2025_01_01)
                    {
                        Parent = controller,
                    };
                infra.Add(frontend);

                TrafficControllerAssociation association =
                    new(nameof(association), TrafficControllerAssociation.ResourceVersions.V2025_01_01)
                    {
                        Parent = controller,
                        AssociationType = TrafficControllerAssociationType.Subnets,
                        SubnetId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet"),
                    };
                infra.Add(association);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateTrafficController()
    {
        await using Trycep test = CreateTrafficControllerTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource controller 'Microsoft.ServiceNetworking/trafficControllers@2025-01-01' = {
              name: take('controller-${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
            }

            resource frontend 'Microsoft.ServiceNetworking/trafficControllers/frontends@2025-01-01' = {
              name: take('frontend-${uniqueString(resourceGroup().id)}', 24)
              location: location
              parent: controller
            }

            resource association 'Microsoft.ServiceNetworking/trafficControllers/associations@2025-01-01' = {
              name: take('association-${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                associationType: 'subnets'
                subnet: {
                  id: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet'
                }
              }
              parent: controller
            }
            """);
    }
}
