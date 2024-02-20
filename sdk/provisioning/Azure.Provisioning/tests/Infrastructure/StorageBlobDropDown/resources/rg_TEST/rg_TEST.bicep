
resource storageAccount_xksvj6bLA 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct420f4454773442c'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_OX8Ox5p80 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_xksvj6bLA
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
