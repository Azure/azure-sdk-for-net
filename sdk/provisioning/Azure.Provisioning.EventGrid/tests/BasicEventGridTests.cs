// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.EventGrid.Tests;

public class BasicEventGridTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.eventgrid/event-grid-subscription-and-storage/main.bicep")]
    public async Task CreateEventGridForBlobs()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter webhookUri = new(nameof(webhookUri), typeof(string));
                infra.Add(webhookUri);

                StorageAccount storage =
                    new(nameof(storage))
                    {
                        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                        Kind = StorageKind.StorageV2,
                        AllowBlobPublicAccess = false,
                        AccessTier = StorageAccountAccessTier.Hot,
                        EnableHttpsTrafficOnly = true,
                    };
                infra.Add(storage);

                SystemTopic topic =
                    new(nameof(topic))
                    {
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                        Source = storage.Id,
                        TopicType = "Microsoft.Storage.StorageAccounts"
                    };
                infra.Add(topic);

                SystemTopicEventSubscription subscription =
                    new(nameof(subscription))
                    {
                        Parent = topic,
                        Destination = new WebHookEventSubscriptionDestination { Endpoint = webhookUri },
                        Filter = new EventSubscriptionFilter
                        {
                            IncludedEventTypes =
                            {
                                "Microsoft.Storage.BlobCreated",
                                "Microsoft.Storage.BlobDeleted"
                            }
                        }
                    };
                infra.Add(subscription);

                return infra;
            })
        .Compare(
            """
            param webhookUri string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource storage 'Microsoft.Storage/storageAccounts@2024-01-01' = {
              name: take('storage${uniqueString(resourceGroup().id)}', 24)
              kind: 'StorageV2'
              location: location
              sku: {
                name: 'Standard_LRS'
              }
              properties: {
                accessTier: 'Hot'
                allowBlobPublicAccess: false
                supportsHttpsTrafficOnly: true
              }
            }

            resource topic 'Microsoft.EventGrid/systemTopics@2022-06-15' = {
              name: take('topic${uniqueString(resourceGroup().id)}', 24)
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                source: storage.id
                topicType: 'Microsoft.Storage.StorageAccounts'
              }
            }

            resource subscription 'Microsoft.EventGrid/systemTopics/eventSubscriptions@2022-06-15' = {
              name: take('subscription${uniqueString(resourceGroup().id)}', 24)
              properties: {
                destination: {
                  endpointType: 'WebHook'
                  properties: {
                    endpointUrl: webhookUri
                  }
                }
                filter: {
                  includedEventTypes: [
                    'Microsoft.Storage.BlobCreated'
                    'Microsoft.Storage.BlobDeleted'
                  ]
                }
              }
              parent: topic
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
