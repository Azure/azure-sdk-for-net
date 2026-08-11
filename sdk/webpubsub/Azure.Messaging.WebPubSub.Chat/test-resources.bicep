param baseName string = resourceGroup().name
param testApplicationOid string
param location string = resourceGroup().location
param supportsSafeSecretStandard bool = false

var webPubSubName = 'e2e-chat-${baseName}'
var storageAccountName = 'chat${uniqueString(resourceGroup().id)}'
var webPubSubApiVersion = '2024-04-01-preview'
var ownerRoleId = '12cf5a90-567b-43ae-8102-96cf46c7d9b4'
var blobDataContributorRoleId = 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'
var tableDataContributorRoleId = '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3'
var queueDataContributorRoleId = '974c5e8b-45b9-4653-ba55-5f855dd0fb88'

resource webPubSub 'Microsoft.SignalRService/webPubSub@2025-12-01-preview' = {
  name: webPubSubName
  location: location
  kind: 'WebPubSub'
  identity: {
    type: 'SystemAssigned'
  }
  sku: {
    name: 'Standard_S1'
    tier: 'Standard'
    capacity: 1
  }
  properties: {
    tls: {
      clientCertEnabled: false
    }
    networkACLs: {
      defaultAction: 'Deny'
      publicNetwork: {
        allow: [
          'ServerConnection'
          'ClientConnection'
          'RESTAPI'
          'Trace'
        ]
      }
      privateEndpoints: []
    }
    disableLocalAuth: supportsSafeSecretStandard
  }
}

resource storageAccount 'Microsoft.Storage/storageAccounts@2023-05-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    allowBlobPublicAccess: false
    minimumTlsVersion: 'TLS1_2'
    supportsHttpsTrafficOnly: true
  }
}

resource blobDataContributorRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(webPubSub.id, storageAccount.id, blobDataContributorRoleId)
  scope: storageAccount
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', blobDataContributorRoleId)
    principalId: webPubSub.identity.principalId
    principalType: 'ServicePrincipal'
  }
}

resource tableDataContributorRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(webPubSub.id, storageAccount.id, tableDataContributorRoleId)
  scope: storageAccount
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', tableDataContributorRoleId)
    principalId: webPubSub.identity.principalId
    principalType: 'ServicePrincipal'
  }
}

resource queueDataContributorRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(webPubSub.id, storageAccount.id, queueDataContributorRoleId)
  scope: storageAccount
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', queueDataContributorRoleId)
    principalId: webPubSub.identity.principalId
    principalType: 'ServicePrincipal'
  }
}

resource persistentStorage 'Microsoft.SignalRService/webPubSub/persistentStorages@2025-12-01-preview' = {
  name: 'chatstorage'
  parent: webPubSub
  properties: {
    storageAccount: {
      id: storageAccount.id
    }
  }
  dependsOn: [
    blobDataContributorRoleAssignment
    tableDataContributorRoleAssignment
    queueDataContributorRoleAssignment
  ]
}

resource chatHub 'Microsoft.SignalRService/webPubSub/hubs@2025-12-01-preview' = {
  name: 'test_hub'
  parent: webPubSub
  properties: {
    chat: {
      mode: 'Enabled'
      persistentStorage: {
        id: persistentStorage.id
      }
    }
  }
}

resource ownerRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('ownerRoleId', webPubSub.id)
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', ownerRoleId)
    principalId: testApplicationOid
  }
}

output WPS_CHAT_ENDPOINT string = 'https://${webPubSub.properties.hostName}'
output WPS_CHAT_CONNECTION_STRING string = listKeys(webPubSub.id, webPubSubApiVersion).primaryConnectionString