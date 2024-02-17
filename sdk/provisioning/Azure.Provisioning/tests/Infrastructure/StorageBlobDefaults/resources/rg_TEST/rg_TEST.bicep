
resource storageAccount_ZdNhg6fih 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-bd564493a58542'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_sgstFalhm 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_ZdNhg6fih
  name: 'default'
  properties: {
    cors: {
    }
  }
}
