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
