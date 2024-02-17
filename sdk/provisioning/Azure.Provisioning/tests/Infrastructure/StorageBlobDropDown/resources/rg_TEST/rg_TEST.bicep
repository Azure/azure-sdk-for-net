
resource storageAccount_gzXK780Fx 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-4341cc8e997a46'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_SjmRxBBDk 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_gzXK780Fx
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
