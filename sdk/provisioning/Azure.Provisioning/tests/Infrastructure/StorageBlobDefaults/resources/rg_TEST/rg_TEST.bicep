
resource storageAccount_uACxct9wM 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-7721a55fbc0c4a'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_BUffwV226 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_uACxct9wM
  name: 'default'
  properties: {
    cors: {
    }
  }
}
