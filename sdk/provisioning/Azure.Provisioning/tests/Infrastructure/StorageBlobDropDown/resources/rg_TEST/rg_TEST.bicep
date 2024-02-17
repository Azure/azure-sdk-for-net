
resource storageAccount_VxW2VK5mj 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-db11bfaa1d4440'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_PVuPa9ZJY 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_VxW2VK5mj
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
