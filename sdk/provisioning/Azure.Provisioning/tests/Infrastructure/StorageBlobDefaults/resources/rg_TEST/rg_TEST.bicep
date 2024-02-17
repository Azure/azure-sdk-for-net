
resource storageAccount_DTVt1E5E0 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-aefbd255b6c64f'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_MUZ5umq8q 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_DTVt1E5E0
  name: 'default'
  properties: {
    cors: {
    }
  }
}
