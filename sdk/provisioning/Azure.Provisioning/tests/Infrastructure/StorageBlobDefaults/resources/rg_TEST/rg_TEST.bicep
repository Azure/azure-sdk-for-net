
resource storageAccount_erCuJ7Pw9 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-1815add998a44a'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_U1fNgMXv7 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_erCuJ7Pw9
  name: 'default'
  properties: {
    cors: {
    }
  }
}
