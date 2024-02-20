
resource storageAccount_dRf5fGWqc 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-2c6cc8edf26e46'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_HqqKb1LF5 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_dRf5fGWqc
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
