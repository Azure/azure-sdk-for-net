
resource storageAccount_QWazYJjM3 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-640857a5e25240'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_GcXijO1R3 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_QWazYJjM3
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
