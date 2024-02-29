targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource storageAccount_1JetI2q6o 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_vupTLRqwy 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_1JetI2q6o
  name: 'default'
  properties: {
  }
}
