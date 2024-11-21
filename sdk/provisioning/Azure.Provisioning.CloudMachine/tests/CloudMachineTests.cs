// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.CloudMachine.KeyVault;
using Azure.CloudMachine.OpenAI;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Test]
    public void GenerateBicep()
    {
        CloudMachineInfrastructure? infra = default;
        CloudMachineCommands.Execute(["-bicep"], (CloudMachineInfrastructure infrastructure) =>
        {
            infra = infrastructure;
            infrastructure.AddFeature(new KeyVaultFeature());
            infrastructure.AddFeature(new OpenAIModel("gpt-35-turbo", "0125"));
            infrastructure.AddFeature(new OpenAIModel("text-embedding-ada-002", "2", AIModelKind.Embedding));
        }, exitProcessIfHandled: false);

        string bicep = infra!.Build().Compile().FirstOrDefault().Value;

        Assert.AreEqual($$"""
@description('The location for the resource(s) to be deployed.')
param location string = resourceGroup().location

param principalId string

@description('The location for the resource(s) to be deployed.')
param location string = resourceGroup().location

resource cm_identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: '{{infra.Id}}'
  location: location
}

resource cm_storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: '{{infra.Id}}'
  kind: 'StorageV2'
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  properties: {
    allowBlobPublicAccess: false
    isHnsEnabled: true
  }
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${cm_identity.id}': { }
    }
  }
}

resource cm_storage_StorageBlobDataContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_storage.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalType: 'User'
  }
  scope: cm_storage
}

resource cm_storage_StorageTableDataContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_storage.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3')
    principalType: 'User'
  }
  scope: cm_storage
}

resource cm_storage_blobs_container 'Microsoft.Storage/storageAccounts/blobServices/containers@2023-01-01' = {
  name: 'default'
  parent: cm_storage_blobs
}

resource cm_storage_blobs 'Microsoft.Storage/storageAccounts/blobServices@2024-01-01' = {
  name: 'default'
  parent: cm_storage
}

resource cm_servicebus 'Microsoft.ServiceBus/namespaces@2024-01-01' = {
  name: '{{infra.Id}}'
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
}

resource cm_servicebus_AzureServiceBusDataOwner 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_servicebus.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419')
    principalType: 'User'
  }
  scope: cm_servicebus
}

resource cm_servicebus_auth_rule 'Microsoft.ServiceBus/namespaces/AuthorizationRules@2021-11-01' = {
  name: take('cm_servicebus_auth_rule-${uniqueString(resourceGroup().id)}', 50)
  properties: {
    rights: [
      'Listen'
      'Send'
      'Manage'
    ]
  }
  parent: cm_servicebus
}

resource cm_servicebus_topic_private 'Microsoft.ServiceBus/namespaces/topics@2021-11-01' = {
  name: 'cm_servicebus_topic_private'
  properties: {
    defaultMessageTimeToLive: 'P14D'
    enableBatchedOperations: true
    maxMessageSizeInKilobytes: 256
    requiresDuplicateDetection: false
    status: 'Active'
    supportOrdering: true
  }
  parent: cm_servicebus
}

resource cm_servicebus_topic_default 'Microsoft.ServiceBus/namespaces/topics@2021-11-01' = {
  name: 'cm_servicebus_default_topic'
  properties: {
    defaultMessageTimeToLive: 'P14D'
    enableBatchedOperations: true
    maxMessageSizeInKilobytes: 256
    requiresDuplicateDetection: false
    status: 'Active'
    supportOrdering: true
  }
  parent: cm_servicebus
}

resource cm_servicebus_subscription_private 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' = {
  name: 'cm_servicebus_subscription_private'
  properties: {
    deadLetteringOnFilterEvaluationExceptions: true
    deadLetteringOnMessageExpiration: true
    defaultMessageTimeToLive: 'P14D'
    enableBatchedOperations: true
    isClientAffine: false
    lockDuration: 'PT30S'
    maxDeliveryCount: 10
    requiresSession: false
    status: 'Active'
  }
  parent: cm_servicebus_topic_private
}

resource cm_servicebus_subscription_default 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' = {
  name: 'cm_servicebus_subscription_default'
  properties: {
    deadLetteringOnFilterEvaluationExceptions: true
    deadLetteringOnMessageExpiration: true
    defaultMessageTimeToLive: 'P14D'
    enableBatchedOperations: true
    isClientAffine: false
    lockDuration: 'PT30S'
    maxDeliveryCount: 10
    requiresSession: false
    status: 'Active'
  }
  parent: cm_servicebus_topic_default
}

resource cm_servicebus_role 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_servicebus.id, cm_identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '69a216fc-b8fb-44d8-bc22-1f3c2cd27a39'))
  properties: {
    principalId: cm_identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '69a216fc-b8fb-44d8-bc22-1f3c2cd27a39')
    principalType: 'ServicePrincipal'
  }
  scope: cm_servicebus
}

resource cm_eventgrid_subscription_blob 'Microsoft.EventGrid/systemTopics/eventSubscriptions@2022-06-15' = {
  name: 'cm-eventgrid-subscription-blob'
  properties: {
    deliveryWithResourceIdentity: {
      identity: {
        type: 'UserAssigned'
        userAssignedIdentity: cm_identity.id
      }
      destination: {
        endpointType: 'ServiceBusTopic'
        properties: {
          resourceId: cm_servicebus_topic_private.id
        }
      }
    }
    eventDeliverySchema: 'EventGridSchema'
    filter: {
      includedEventTypes: [
        'Microsoft.Storage.BlobCreated'
        'Microsoft.Storage.BlobDeleted'
        'Microsoft.Storage.BlobRenamed'
      ]
      enableAdvancedFilteringOnArrays: true
    }
    retryPolicy: {
      maxDeliveryAttempts: 30
      eventTimeToLiveInMinutes: 1440
    }
  }
  parent: cm_eventgrid_topic_blob
  dependsOn: [
    cm_servicebus_role
  ]
}

resource cm_eventgrid_topic_blob 'Microsoft.EventGrid/systemTopics@2022-06-15' = {
  name: '{{infra.Id}}'
  location: location
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${cm_identity.id}': { }
    }
  }
  properties: {
    source: cm_storage.id
    topicType: 'Microsoft.Storage.StorageAccounts'
  }
}

resource cm_kv 'Microsoft.KeyVault/vaults@2023-07-01' = {
  name: '{{infra.Id}}'
  location: location
  properties: {
    tenantId: subscription().tenantId
    sku: {
      family: 'A'
      name: 'standard'
    }
    accessPolicies: [
      {
        tenantId: cm_identity.properties.tenantId
        objectId: principalId
        permissions: {
          secrets: [
            'get'
            'set'
          ]
        }
      }
    ]
    enabledForDeployment: true
  }
}

resource cm_kv_KeyVaultAdministrator 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_kv.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '00482a5a-887f-4fb3-b363-3b7fe8e74483'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '00482a5a-887f-4fb3-b363-3b7fe8e74483')
    principalType: 'User'
  }
  scope: cm_kv
}

resource cm_kv_cm_identity_KeyVaultAdministrator 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_kv.id, cm_identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '00482a5a-887f-4fb3-b363-3b7fe8e74483'))
  properties: {
    principalId: cm_identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '00482a5a-887f-4fb3-b363-3b7fe8e74483')
    principalType: 'ServicePrincipal'
  }
  scope: cm_kv
}

resource openai 'Microsoft.CognitiveServices/accounts@2024-10-01' = {
  name: '{{infra.Id}}'
  location: location
  kind: 'OpenAI'
  properties: {
    customSubDomainName: '{{infra.Id}}'
    publicNetworkAccess: 'Enabled'
  }
  sku: {
    name: 'S0'
  }
}

resource openai_CognitiveServicesOpenAIContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(openai.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442')
    principalType: 'User'
  }
  scope: openai
}

resource openai_{{infra.Id}}_chat 'Microsoft.CognitiveServices/accounts/deployments@2024-06-01-preview' = {
  name: '{{infra.Id}}_chat'
  properties: {
    model: {
      format: 'OpenAI'
      name: 'gpt-35-turbo'
      version: '0125'
    }
    raiPolicyName: 'Microsoft.DefaultV2'
    versionUpgradeOption: 'OnceNewDefaultVersionAvailable'
  }
  sku: {
    name: 'Standard'
    capacity: 120
  }
  parent: openai
}

resource openai_{{infra.Id}}_embedding 'Microsoft.CognitiveServices/accounts/deployments@2024-06-01-preview' = {
  name: '{{infra.Id}}_embedding'
  properties: {
    model: {
      format: 'OpenAI'
      name: 'text-embedding-ada-002'
      version: '2'
    }
    raiPolicyName: 'Microsoft.DefaultV2'
    versionUpgradeOption: 'OnceNewDefaultVersionAvailable'
  }
  sku: {
    name: 'Standard'
    capacity: 120
  }
  parent: openai
  dependsOn: [
    openai_{{infra.Id}}_chat
  ]
}

resource cm_storage_StorageBlobDataContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_storage.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalType: 'User'
  }
  scope: cm_storage
}

resource cm_storage_StorageTableDataContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_storage.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3')
    principalType: 'User'
  }
  scope: cm_storage
}

resource cm_servicebus_AzureServiceBusDataOwner 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_servicebus.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419')
    principalType: 'User'
  }
  scope: cm_servicebus
}

resource cm_servicebus_role 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_servicebus.id, cm_identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '69a216fc-b8fb-44d8-bc22-1f3c2cd27a39'))
  properties: {
    principalId: cm_identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '69a216fc-b8fb-44d8-bc22-1f3c2cd27a39')
    principalType: 'ServicePrincipal'
  }
  scope: cm_servicebus
}

output cm_managed_identity_id string = cm_identity.id

output storage_name string = cm_storage.name

output servicebus_name string = cm_servicebus.name

output storage_name string = cm_storage.name

output servicebus_name string = cm_servicebus.name
""", bicep);
    }

    [Test]
    public void GenerateBicepWithRoleResolver()
    {
        Dictionary<Provisionable, string[]> annotations = [];

        Infrastructure infra = new();

        StorageAccount storage = new(nameof(storage))
        {
            Sku = { Name = StorageSkuName.StandardLrs },
            Kind = StorageKind.StorageV2
        };
        annotations[storage] = [StorageBuiltInRole.StorageBlobDataOwner.ToString(), StorageBuiltInRole.StorageAccountContributor.ToString()];
        infra.Add(storage);

        StorageAccount second = new(nameof(second)) { Sku = { Name = StorageSkuName.StandardLrs }, Kind = StorageKind.StorageV2 };
        annotations[second] = [StorageBuiltInRole.StorageAccountContributor.ToString()];
        infra.Add(second);

        UserAssignedIdentity identity = new(nameof(identity));
        infra.Add(identity);
        ProvisioningBuildOptions options = new() { InfrastructureResolvers = { new RoleResolver(annotations, identity) } };
        ProvisioningPlan plan = infra.Build(options);
        var actualBicep = plan.Compile().FirstOrDefault().Value;
        Assert.AreEqual("""
@description('The location for the resource(s) to be deployed.')
param location string = resourceGroup().location

resource storage 'Microsoft.Storage/storageAccounts@2024-01-01' = {
  name: take('storage${uniqueString(resourceGroup().id)}', 24)
  kind: 'StorageV2'
  location: location
  sku: {
    name: 'Standard_LRS'
  }
}

resource storage_standardroles_1 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('storage', identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'b7e6dc6d-f1e8-4753-8033-0f276bb0955b'))
  properties: {
    principalId: identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'b7e6dc6d-f1e8-4753-8033-0f276bb0955b')
    principalType: 'ServicePrincipal'
  }
  scope: storage
}

resource storage_standardroles_2 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('storage', identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '17d1049b-9a84-46fb-8f53-869881c3d3ab'))
  properties: {
    principalId: identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '17d1049b-9a84-46fb-8f53-869881c3d3ab')
    principalType: 'ServicePrincipal'
  }
  scope: storage
}

resource second 'Microsoft.Storage/storageAccounts@2024-01-01' = {
  name: take('second${uniqueString(resourceGroup().id)}', 24)
  kind: 'StorageV2'
  location: location
  sku: {
    name: 'Standard_LRS'
  }
}

resource second_standardroles_1 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('second', identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '17d1049b-9a84-46fb-8f53-869881c3d3ab'))
  properties: {
    principalId: identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '17d1049b-9a84-46fb-8f53-869881c3d3ab')
    principalType: 'ServicePrincipal'
  }
  scope: second
}

resource identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: take('identity-${uniqueString(resourceGroup().id)}', 128)
  location: location
}
""", actualBicep);
    }

    [Ignore("no recordings yet")]
    [Test]
    public void ListModels()
    {
        CloudMachineCommands.Execute(["-ai", "chat"], exitProcessIfHandled: false);
    }
}
