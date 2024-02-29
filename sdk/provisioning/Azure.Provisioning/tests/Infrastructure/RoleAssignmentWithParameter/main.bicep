targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('')
param principalId string


resource storageAccount_jW2g4ryFz 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_a6I9rA4wm 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_jW2g4ryFz
  name: 'default'
  properties: {
  }
}

resource roleAssignment_nQO6JfG3m 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_jW2g4ryFz
  name: guid('storageAccount_jW2g4ryFz', principalId, 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: principalId
  }
}
