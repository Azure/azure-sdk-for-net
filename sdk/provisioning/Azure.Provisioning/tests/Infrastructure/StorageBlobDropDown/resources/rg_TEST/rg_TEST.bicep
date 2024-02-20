
resource storageAccount_F00UduuIF 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct05f2f60511ac497'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_L1IVWfLBd 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_F00UduuIF
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
