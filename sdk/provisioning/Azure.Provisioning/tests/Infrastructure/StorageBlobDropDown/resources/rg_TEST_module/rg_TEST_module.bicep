
resource storageAccount_dx0zUTplq 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacctc31a9d6584644ae'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_PYZrLaKZo 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_dx0zUTplq
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
