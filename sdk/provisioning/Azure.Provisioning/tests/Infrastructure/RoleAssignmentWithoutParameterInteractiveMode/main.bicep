targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource storageAccount_fC1PdnL8P 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_9ZU5qOvY8 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_fC1PdnL8P
  name: 'default'
  properties: {
  }
}

resource roleAssignment_ZdHqsyZeo 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_fC1PdnL8P
  name: guid('storageAccount_fC1PdnL8P', '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: '00000000-0000-0000-0000-000000000000'
  }
}
