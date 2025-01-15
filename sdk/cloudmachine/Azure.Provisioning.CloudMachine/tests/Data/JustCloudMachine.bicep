@description('The location for the resource(s) to be deployed.')
param location string = resourceGroup().location

@description('The objectId of the current user principal.')
param principalId string

resource cm_identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: 'cm0c420d2f21084cd'
  location: location
}

resource cm_storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: 'cm0c420d2f21084cd'
  kind: 'StorageV2'
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  properties: {
    allowBlobPublicAccess: false
    allowSharedKeyAccess: false
    isHnsEnabled: true
  }
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${cm_identity.id}': { }
    }
  }
}

resource cm_storage_1_StorageBlobDataContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('cm_storage', 'cm0c420d2f21084cd', principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalType: 'User'
  }
  scope: cm_storage
}

resource cm_storage_cm_identity_StorageBlobDataContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('cm_storage', cm_identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    principalId: cm_identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalType: 'ServicePrincipal'
  }
  scope: cm_storage
}

resource cm_storage_1_StorageTableDataContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('cm_storage', 'cm0c420d2f21084cd', principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3')
    principalType: 'User'
  }
  scope: cm_storage
}

resource cm_storage_cm_identity_StorageTableDataContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('cm_storage', cm_identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3'))
  properties: {
    principalId: cm_identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3')
    principalType: 'ServicePrincipal'
  }
  scope: cm_storage
}

resource cm_storage_blobs 'Microsoft.Storage/storageAccounts/blobServices@2024-01-01' = {
  name: 'default'
  parent: cm_storage
}

resource cm_storage_blobs_container_default 'Microsoft.Storage/storageAccounts/blobServices/containers@2023-01-01' = {
  name: 'default'
  parent: cm_storage_blobs
}

resource cm_servicebus 'Microsoft.ServiceBus/namespaces@2024-01-01' = {
  name: 'cm0c420d2f21084cd'
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
}

resource cm_servicebus_1_AzureServiceBusDataOwner 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('cm_servicebus', 'cm0c420d2f21084cd', principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419')
    principalType: 'User'
  }
  scope: cm_servicebus
}

resource cm_servicebus_cm_identity_AzureServiceBusDataOwner 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('cm_servicebus', cm_identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419'))
  properties: {
    principalId: cm_identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419')
    principalType: 'ServicePrincipal'
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

resource cm_servicebus_default_topic 'Microsoft.ServiceBus/namespaces/topics@2021-11-01' = {
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
  parent: cm_servicebus_default_topic
}

resource cm_eventgrid_topic 'Microsoft.EventGrid/systemTopics@2022-06-15' = {
  name: 'cm0c420d2f21084cd'
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
  parent: cm_eventgrid_topic
  dependsOn: [
    cm_servicebus_cm0c420d2f21084cd_role
  ]
}

resource cm_servicebus_cm0c420d2f21084cd_role 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(cm_servicebus.id, cm_identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '69a216fc-b8fb-44d8-bc22-1f3c2cd27a39'))
  properties: {
    principalId: cm_identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '69a216fc-b8fb-44d8-bc22-1f3c2cd27a39')
    principalType: 'ServicePrincipal'
  }
  scope: cm_servicebus
}

output cm_managed_identity_id string = cm_identity.id
