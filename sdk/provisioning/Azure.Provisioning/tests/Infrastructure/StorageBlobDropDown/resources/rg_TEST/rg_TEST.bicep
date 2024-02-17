
resource storageAccount_w0IyPyjWx 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-40c65c3529144b'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_n5wAMCYIG 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_w0IyPyjWx
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
