// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.EventGrid.Tests;

public class BasicEventGridTests
{
    internal static Trycep CreateEventGridForBlobsTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:EventGridBasic
                Infrastructure infra = new();

                ProvisioningParameter webhookUri = new(nameof(webhookUri), typeof(string));
                infra.Add(webhookUri);

                StorageAccount storage =
                    new(nameof(storage), StorageAccount.ResourceVersions.V2024_01_01)
                    {
                        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                        Kind = StorageKind.StorageV2,
                        AllowBlobPublicAccess = false,
                        AccessTier = StorageAccountAccessTier.Hot,
                        EnableHttpsTrafficOnly = true,
                    };
                infra.Add(storage);

                SystemTopic topic =
                    new(nameof(topic), SystemTopic.ResourceVersions.V2022_06_15)
                    {
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                        Source = storage.Id,
                        TopicType = "Microsoft.Storage.StorageAccounts"
                    };
                infra.Add(topic);

                SystemTopicEventSubscription subscription =
                    new(nameof(subscription), SystemTopicEventSubscription.ResourceVersions.V2022_06_15)
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
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.eventgrid/event-grid-subscription-and-storage/main.bicep")]
    public async Task CreateEventGridForBlobs()
    {
        await using Trycep test = CreateEventGridForBlobsTest();
        test.Compare(
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
            """);
    }
}
