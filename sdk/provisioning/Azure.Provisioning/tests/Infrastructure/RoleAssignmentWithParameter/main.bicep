targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('')
param principalId string


resource storageAccount_7EH24TZOS 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('photoAcct${uniqueString(resourceGroup().id)}', 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
  }
}

resource blobService_7QL3qUuBS 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_7EH24TZOS
  name: 'default'
  properties: {
  }
}

resource roleAssignment_NfInNFBlY 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: storageAccount_7EH24TZOS
  name: guid(storageAccount_7EH24TZOS.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: principalId
    principalType: 'ServicePrincipal'
  }
}

resource roleAssignment_cmAstwnTk 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: storageAccount_7EH24TZOS
  name: guid(storageAccount_7EH24TZOS.id, principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '974c5e8b-45b9-4653-ba55-5f855dd0fb88'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '974c5e8b-45b9-4653-ba55-5f855dd0fb88')
    principalId: principalId
    principalType: 'ServicePrincipal'
  }
}

resource roleAssignment_4GhzPkC6K 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: storageAccount_7EH24TZOS
  name: guid(storageAccount_7EH24TZOS.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'User'
  }
}
