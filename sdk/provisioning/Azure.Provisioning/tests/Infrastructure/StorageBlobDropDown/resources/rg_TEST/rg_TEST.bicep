
resource storageAccount_ueMvHVxRn 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-745e82f87b8643'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_LNZp3bela 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_ueMvHVxRn
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
