
resource storageAccount_GZYFQDrQ7 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-93297634c2184e'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_zYYZUU0bM 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_GZYFQDrQ7
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
