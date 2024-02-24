
resource storageAccount_hdYM4y68e 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoaccte57722fb9872441'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_Od7SLNmXY 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_hdYM4y68e
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
