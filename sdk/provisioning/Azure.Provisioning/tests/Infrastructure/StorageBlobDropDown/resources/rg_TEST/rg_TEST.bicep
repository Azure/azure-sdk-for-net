
resource storageAccount_3NwCr26bs 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-0a5678be9deb41'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_A6eisTKKC 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_3NwCr26bs
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
