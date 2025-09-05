// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.EventHubs.Tests;

public class BasicEventHubsTests
{
    internal static Trycep CreateEventHubAndConsumerGroupTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:EventHubsBasic
                Infrastructure infra = new();

                ProvisioningParameter hubName = new(nameof(hubName), typeof(string)) { Value = "orders" };
                infra.Add(hubName);

                ProvisioningParameter groupName = new(nameof(groupName), typeof(string)) { Value = "managers" };
                infra.Add(groupName);

                EventHubsNamespace ns =
                    new(nameof(ns))
                    {
                        Sku = new EventHubsSku
                        {
                            Name = EventHubsSkuName.Standard,
                            Tier = EventHubsSkuTier.Standard,
                            Capacity = 1
                        }
                    };
                infra.Add(ns);

                EventHub hub =
                    new(nameof(hub))
                    {
                        Parent = ns,
                        Name = hubName
                    };
                infra.Add(hub);

                EventHubsConsumerGroup group =
                    new(nameof(group))
                    {
                        Parent = hub,
                        Name = groupName,
                        UserMetadata = BinaryData.FromObjectAsJson(new { foo = 1, bar = "hello" }).ToString()
                    };
                infra.Add(group);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.eventhub/event-hubs-create-event-hub-and-consumer-group/main.bicep")]
    public async Task CreateEventHubAndConsumerGroup()
    {
        await using Trycep test = CreateEventHubAndConsumerGroupTest();
        test.Compare(
            """
            param hubName string = 'orders'

            param groupName string = 'managers'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource ns 'Microsoft.EventHub/namespaces@2024-01-01' = {
              name: take('ns-${uniqueString(resourceGroup().id)}', 256)
              location: location
              sku: {
                name: 'Standard'
                tier: 'Standard'
                capacity: 1
              }
            }

            resource hub 'Microsoft.EventHub/namespaces/eventhubs@2024-01-01' = {
              name: hubName
              parent: ns
            }

            resource group 'Microsoft.EventHub/namespaces/eventhubs/consumergroups@2024-01-01' = {
              name: groupName
              properties: {
                userMetadata: '{"foo":1,"bar":"hello"}'
              }
              parent: hub
            }
            """);
    }
}
