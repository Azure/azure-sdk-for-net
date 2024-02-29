targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource storageAccount_YRiDhR43q 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_lnEDXlX5c 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_YRiDhR43q
  name: 'default'
  properties: {
  }
}

resource roleAssignment_ZBWGKDk4O 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_YRiDhR43q
  name: guid('storageAccount_YRiDhR43q', '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: '00000000-0000-0000-0000-000000000000'
  }
}
