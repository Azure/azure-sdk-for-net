
resource storageAccount_7Spem00ph 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct4aa56e7da51149b'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_Al1mntjNG 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_7Spem00ph
  name: 'default'
  properties: {
    cors: {
    }
  }
}
