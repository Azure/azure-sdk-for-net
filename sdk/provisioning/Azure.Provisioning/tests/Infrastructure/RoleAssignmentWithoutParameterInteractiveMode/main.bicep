targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource storageAccount_XJNeT6Eti 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_A96Cuv27c 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_XJNeT6Eti
  name: 'default'
  properties: {
  }
}

resource roleAssignment_5PbYbRPAD 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_XJNeT6Eti
  name: guid('storageAccount_XJNeT6Eti', '00000000-0000-0000-0000-000000000000', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: '00000000-0000-0000-0000-000000000000'
  }
}
