
resource storageAccount_8bHLfyPqi 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-8886a0cd521940'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_XWfhyHJIP 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_8bHLfyPqi
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
