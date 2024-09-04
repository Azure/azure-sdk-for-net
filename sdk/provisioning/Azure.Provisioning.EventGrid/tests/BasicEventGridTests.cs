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
    [RecordedTest]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.eventgrid/event-grid-subscription-and-storage/main.bicep")]
    public async Task CreateEventGridForBlobs()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "Service location.";

                BicepParameter webhookUri = BicepParameter.Create<string>(nameof(webhookUri));

                StorageAccount storage =
                    new(nameof(storage))
                    {
                        Location = location,
                        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                        Kind = StorageKind.StorageV2,
                        AllowBlobPublicAccess = false,
                        AccessTier = StorageAccountAccessTier.Hot,
                        EnableHttpsTrafficOnly = true,
                    };
                SystemTopic topic =
                    new(nameof(topic))
                    {
                        Location = location,
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                        Source = storage.Id,
                        TopicType = "Microsoft.Storage.StorageAccounts"
                    };
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
            })
        .Compare(
            """
            @description('Service location.')
            param location string = resourceGroup().location

            param webhookUri string

            resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
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
