
resource storageAccount_YKJfRyF7O 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-a649dd7d16bb48'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_baXQKLZ5y 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_YKJfRyF7O
  name: 'default'
  properties: {
    cors: {
    }
  }
}
