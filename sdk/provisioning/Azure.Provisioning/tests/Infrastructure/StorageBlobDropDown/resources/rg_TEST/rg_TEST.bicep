
resource storageAccount_cbqpTzUq1 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-e6cc582c16114a'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_rkzENGcjp 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_cbqpTzUq1
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
